
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

    public int sugar { get; private set; }
    public readonly int vision;
    public readonly int metabolism;
    public readonly Sex sex;
    public int age { get; private set; } = 0;

    public Location location;

    public GameObject gameObject;

    public Agent () {
        this.id = NEXT_ID++;
        this.sugar = Utils.RandomIntBetween(Simulation.Parameters.Endowment.MIN, Simulation.Parameters.Endowment.MAX);
        this.vision = Utils.RandomIntBetween(Simulation.Parameters.Vision.MIN, Simulation.Parameters.Vision.MAX);
        this.metabolism = Utils.RandomIntBetween(Simulation.Parameters.Metabolism.MIN, Simulation.Parameters.Metabolism.MAX);
        this.sex = Random.value < 0.5 ? Sex.MALE : Sex.FEMALE;
        InitGameObject();
    }

    public void Destroy () {
        Object.Destroy(gameObject);
    }

    public void Step () {
        this.Move();
        this.Harvest();
        this.Eat();
        if ( sugar < 0 ) {
            this.Die();
        } else {
            this.Age();
        }
    }

    public void Render () {
        gameObject.transform.localPosition = new Vector3(this.location.y, 0, this.location.x);
    }

    private void Move () {
        Location next = this.location;

        foreach ( List<Location> locationsInDirection in Utils.Shuffle(this.location.GetAllLocationsInSight(this.vision)) ) {
            foreach ( Location potential in locationsInDirection ) {
                if ( potential.agent == null && potential.sugar > next.sugar ) {
                    next = potential;
                }
            }
        }

        this.location.agent = null;
        this.location = next;
        this.location.agent = this;
    }

    private void Harvest () {
        this.sugar += this.location.Harvest();
    }

    private void Eat () {
        sugar -= metabolism;
    }

    private void Die () {
        isAlive = false;
        Object.Destroy(gameObject);
    }

    private void Age () {
        this.age++;
    }

    private void InitGameObject () {
        gameObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        gameObject.name = "Agent" + this.id;
        gameObject.transform.localScale = 0.9f * Vector3.one;

        Object.Destroy(gameObject.GetComponent<Collider>());

        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.receiveShadows = false;
        renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        renderer.sharedMaterial = Materials.DEFAULT;
    }

}
