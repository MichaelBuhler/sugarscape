
using UnityEngine;

public class Main : MonoBehaviour {

    void Start()
    {
        InitGround();
        InitCapsules();
    }

    private void InitGround()
    {
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.name = "Ground";
        ground.transform.localScale *= 5;
        ground.transform.localPosition = new Vector3(24.5f, -1, 24.5f);
        GameObject.Destroy(ground.GetComponent<Collider>());
        Renderer renderer = ground.GetComponent<Renderer>();
        renderer.receiveShadows = false;
        renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        renderer.sharedMaterial = Materials.sugarscape;
    }

    private void InitCapsules()
    {
        for (int i = 0; i < 400; i++) {
            GameObject agent = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            agent.name = "Agent" + i;
            agent.transform.localPosition = new Vector3(Utils.RandomInt(50), 0, Utils.RandomInt(50));
            GameObject.Destroy(agent.GetComponent<Collider>());
            Renderer renderer = agent.GetComponent<Renderer>();
            renderer.receiveShadows = false;
            renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            renderer.sharedMaterial = Random.value < 0.5 ? Materials.male : Materials.female;
        }
    }
}
