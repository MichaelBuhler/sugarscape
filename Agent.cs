
using System.Collections.Generic;

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

    public Agent () {
        id = NEXT_ID++;
        endowment = Utils.RandomIntBetween(Simulation.Parameters.Endowment.MIN, Simulation.Parameters.Endowment.MAX);
        sugar = endowment;
        vision = Utils.RandomIntBetween(Simulation.Parameters.Vision.MIN, Simulation.Parameters.Vision.MAX);
        metabolism = Utils.RandomIntBetween(Simulation.Parameters.Metabolism.MIN, Simulation.Parameters.Metabolism.MAX);
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
        } else {
            Age();
        }
    }

    public void Render () {
        gameObject.transform.localPosition = new Vector3(location.y, 0, location.x);
    }

    private void Move () {
        Location next = location;

        foreach ( List<Location> locationsInDirection in Utils.Shuffle(location.GetAllLocationsInSight(vision)) ) {
            foreach ( Location potential in locationsInDirection ) {
                if ( potential.agent == null && potential.sugar > next.sugar ) {
                    next = potential;
                }
            }
        }

        location.agent = null;
        location = next;
        location.agent = this;
    }

    private void Harvest () {
        sugar += location.Harvest();
    }

    private void Eat () {
        sugar -= metabolism;
    }

    private void Die () {
        isAlive = false;
        Object.Destroy(gameObject);
    }

    private void Age () {
        age++;
    }

    private void InitGameObject () {
        gameObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        gameObject.name = "Agent" + id;
        gameObject.transform.localScale = 0.9f * Vector3.one;

        Object.Destroy(gameObject.GetComponent<Collider>());

        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.receiveShadows = false;
        renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        renderer.sharedMaterial = Materials.DEFAULT;
    }

}
