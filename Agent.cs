
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class Agent {

    private static int NEXT_ID = 0;

    public enum Sex {
        MALE,
        FEMALE
    }

    public int id;

    public bool isAlive { get; private set; } = true;

    public readonly int endowment;
    public int sugar { get; private set; }
    public readonly int vision;
    public readonly int metabolism;
    public readonly Sex sex;
    public int age { get; private set; } = 0;
    public readonly int maximumAge;
    public readonly int minimumFertileAge;
    public readonly int maximumFertileAge;
    public bool isFertile {
        get {
            return isAlive && age >= minimumFertileAge && age < maximumFertileAge && sugar >= endowment;
        }
    }

    public Location location;

    public GameObject gameObject;
    public Renderer renderer;

    public Agent () : this(
        Utils.RandomIntBetween(Simulation.Parameters.Endowment.MIN, Simulation.Parameters.Endowment.MAX),
        Utils.RandomIntBetween(Simulation.Parameters.Vision.MIN, Simulation.Parameters.Vision.MAX),
        Utils.RandomIntBetween(Simulation.Parameters.Metabolism.MIN, Simulation.Parameters.Metabolism.MAX)
    ) { }

    public Agent (int endowment, int vision, int metabolism) {
        id = NEXT_ID++;
        this.endowment = endowment;
        sugar = endowment;
        this.vision = vision;
        this.metabolism = metabolism;
        sex = Random.value < 0.5 ? Sex.MALE : Sex.FEMALE;
        maximumAge = Utils.RandomIntBetween(Simulation.Parameters.Lifespan.MIN, Simulation.Parameters.Lifespan.MAX);
        if ( sex == Sex.MALE ) {
            minimumFertileAge = Utils.RandomIntBetween(Simulation.Parameters.Fertility.Male.Begin.MIN, Simulation.Parameters.Fertility.Male.Begin.MAX);
            maximumFertileAge = Utils.RandomIntBetween(Simulation.Parameters.Fertility.Male.End.MIN, Simulation.Parameters.Fertility.Male.End.MAX);
        } else {
            minimumFertileAge = Utils.RandomIntBetween(Simulation.Parameters.Fertility.Female.Begin.MIN, Simulation.Parameters.Fertility.Female.Begin.MAX);
            maximumFertileAge = Utils.RandomIntBetween(Simulation.Parameters.Fertility.Female.End.MIN, Simulation.Parameters.Fertility.Female.End.MAX);
        }
        InitGameObject();
    }

    public void Destroy () {
        Object.Destroy(gameObject);
    }

    public void Step () {
        Move();
        Harvest();
        Eat();
        if ( sugar < 0 || age == maximumAge ) {
            Die();
            return;
        }
        Age();
        if ( isFertile ) {
            Reproduce();
        }
    }

    public void Render () {
        gameObject.transform.localPosition = new Vector3(location.y, 0, location.x);
        switch ( State.COLORING_OPTION ) {
            case State.ColoringOptions.DEFAULT:
                renderer.sharedMaterial = Materials.DEFAULT;
                break;
            case State.ColoringOptions.BY_SEX:
                renderer.sharedMaterial = sex == Sex.MALE ? Materials.MALE : Materials.FEMALE;
                break;
            case State.ColoringOptions.BY_VISION:
                {
                    float firstTercile = Utils.GetFirstTercile(Simulation.Parameters.Vision.MIN, Simulation.Parameters.Vision.MAX);
                    float secondTercile = Utils.GetSecondTercile(Simulation.Parameters.Vision.MIN, Simulation.Parameters.Vision.MAX);
                    if ( vision < firstTercile ) {
                        renderer.sharedMaterial = Materials.LOW_VISION;
                    } else if ( vision <= secondTercile ) {
                        renderer.sharedMaterial = Materials.MEDIUM_VISION;
                    } else {
                        renderer.sharedMaterial = Materials.HIGH_VISION;
                    }
                }
                break;
            case State.ColoringOptions.BY_METABOLISM:
                {
                    float firstTercile = Utils.GetFirstTercile(Simulation.Parameters.Metabolism.MIN, Simulation.Parameters.Metabolism.MAX);
                    float secondTercile = Utils.GetSecondTercile(Simulation.Parameters.Metabolism.MIN, Simulation.Parameters.Metabolism.MAX);
                    if ( metabolism < firstTercile ) {
                        renderer.sharedMaterial = Materials.LOW_METABOLISM;
                    } else if ( metabolism <= secondTercile ) {
                        renderer.sharedMaterial = Materials.MEDIUM_METABOLISM;
                    } else {
                        renderer.sharedMaterial = Materials.HIGH_METABOLISM;
                    }
                }
                break;
        }
    }

    public int ConsumeSugarRequiredToReproduce () {
        int required = Mathf.CeilToInt(endowment / 2f);
        sugar -= required;
        return required;
    }

    private void Move () {
        int nextSugar = -1;
        int potentialSugar = -1;
        Location nextLocation = null;
        Location potentialLocation = null;
        List<List<Location>> allPotentialLocations = Utils.Shuffle(location.GetAllLocationsInSight(vision));

        switch ( Simulation.Parameters.MOVEMENT_STRATEGY ) {
            case Simulation.MovementStrategies.CLASSIC:
                {
                    for ( int i = 0 ; i < vision ; i++ ) {
                        for ( int j = 0 ; j < 4 ; j++ ) {
                            potentialLocation = allPotentialLocations[j][i];
                            if ( potentialLocation.agent != null ) {
                                continue;
                            }
                            potentialSugar = potentialLocation.sugar;
                            if ( nextLocation == null || potentialSugar > nextSugar ) {
                                nextSugar = potentialSugar;
                                nextLocation = potentialLocation;
                            }
                        }
                    }
                }
                break;
            case Simulation.MovementStrategies.CUSTOM:
                {
                    if ( isFertile ) {
                        for ( int i = 0 ; i < vision ; i++ ) {
                            for ( int j = 0 ; j < 4 ; j++ ) {
                                if ( i == 0 ) {
                                    potentialLocation = location;
                                } else {
                                    potentialLocation = allPotentialLocations[j][0];
                                    if ( potentialLocation.agent != null ) {
                                        continue;
                                    }
                                }
                                Agent potentialMate = allPotentialLocations[j][i].agent;
                                if ( potentialMate != null && potentialMate.sex != sex && potentialMate.isFertile ) {
                                    nextLocation = potentialLocation;
                                    j = 4;
                                    i = vision;
                                    break;
                                }
                            }
                        }
                    }
                    if ( nextLocation == null ) {
                        for ( int i = 0 ; i < 4 ; i++ ) {
                            potentialLocation = allPotentialLocations[i][0];
                            if ( potentialLocation.agent != null ) {
                                continue;
                            }
                            potentialSugar = allPotentialLocations[i].Select(x => x.sugar).Sum();
                            if ( nextLocation == null || potentialSugar > nextSugar ) {
                                nextSugar = potentialSugar;
                                nextLocation = potentialLocation;
                            }
                        }
                    }
                }
                break;
        }

        if ( nextLocation != null ) {
            location.agent = null;
            location = nextLocation;
            location.agent = this;
        }
    }

    private void Harvest () {
        sugar += location.Harvest();
    }

    private void Eat () {
        sugar -= metabolism;
    }

    private void Reproduce () {
        List<Agent> oppositeSexNeighbors = GetNeighbors().FindAll(x => x.sex != sex);
        foreach ( Agent neighbor in Utils.Shuffle(oppositeSexNeighbors) ) {
            if ( neighbor.isFertile ) {
                List<Location> potentialLocations = location.GetNeighboringLocations();
                potentialLocations.AddRange(neighbor.location.GetNeighboringLocations());
                potentialLocations = potentialLocations.FindAll(x => x.agent == null);
                potentialLocations = Utils.Shuffle(potentialLocations);
                if ( potentialLocations.Count > 0 ) {
                    int endowment = ConsumeSugarRequiredToReproduce() + neighbor.ConsumeSugarRequiredToReproduce();
                    Agent baby = new Agent(
                        endowment,
                        Random.value < 0.5 ? vision : neighbor.vision,
                        Random.value < 0.5 ? metabolism : neighbor.metabolism
                    );
                    Simulation.agents.Add(baby);
                    baby.location = potentialLocations[0];
                    potentialLocations[0].agent = baby;
                    baby.Render();
                }
            }
        }
    }

    private void Die () {
        isAlive = false;
        location.agent = null;
        Object.Destroy(gameObject);
    }

    private void Age () {
        age++;
    }

    private List<Agent> GetNeighbors () {
        List<Agent> neighbors = new List<Agent>();
        neighbors.Add(location.north.agent);
        neighbors.Add(location.south.agent);
        neighbors.Add(location.east.agent);
        neighbors.Add(location.west.agent);
        return neighbors.FindAll(n => n != null);
    }

    private void InitGameObject () {
        gameObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        gameObject.name = "Agent" + id;
        gameObject.transform.localScale = 0.9f * Vector3.one;

        Object.Destroy(gameObject.GetComponent<Collider>());

        renderer = gameObject.GetComponent<Renderer>();
        renderer.receiveShadows = false;
        renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        renderer.sharedMaterial = Materials.DEFAULT;
    }

}
