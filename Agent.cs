
using UnityEngine;

public class Agent {

    public int id;

    public int sugar;
    public int vision;
    public int metabolism;

    public Location location;

    public GameObject gameObject;

    public Agent (int id) {
        this.id = id;
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
        renderer.sharedMaterial = Random.value < 0.5 ? Materials.MALE : Materials.FEMALE;
    }
}
