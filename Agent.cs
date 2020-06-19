
using UnityEngine;

public class Agent {

    private static int NEXT_ID = 0;

    public int id;

    public int sugar;
    public int vision;
    public int metabolism;

    public Location location;

    public GameObject gameObject;

    public Agent () {
        this.id = NEXT_ID++;
        this.sugar = Utils.RandomIntBetween(Simulation.Parameters.Endowment.MIN, Simulation.Parameters.Endowment.MAX);
        this.vision = Utils.RandomIntBetween(Simulation.Parameters.Vision.MIN, Simulation.Parameters.Vision.MAX);
        this.metabolism = Utils.RandomIntBetween(Simulation.Parameters.Metabolism.MIN, Simulation.Parameters.Metabolism.MAX);
        InitGameObject();
    }

    public void Render () {
        gameObject.transform.localPosition = new Vector3(Utils.RandomInt(50), 0, Utils.RandomInt(50));
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
