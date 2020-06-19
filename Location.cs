
using UnityEngine;

public class Location {

    public readonly int x;
    public readonly int y;
    public readonly int capacity;

    public int sugar { get; private set; }

    public GameObject gameObject;

    public Agent agent;

    public Location (int x, int y, int capacity) {
        this.x = x;
        this.y = y;
        this.capacity = capacity;
        this.sugar = capacity;
        InitGameObject();
    }

    public void Render () {
        gameObject.transform.localScale = Mathf.Sqrt(sugar) * Vector3.one / 25;
    }

    private void InitGameObject () {
        gameObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
        gameObject.name = "Sugar" + x + "," + y;
        gameObject.transform.localScale = Vector3.zero;
        gameObject.transform.localPosition = new Vector3(y, -0.95f, x);

        Object.Destroy(gameObject.GetComponent<Collider>());

        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.receiveShadows = false;
        renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        renderer.sharedMaterial = Materials.SUGAR;
    }

}
