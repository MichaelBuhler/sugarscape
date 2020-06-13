using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
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
        ground.GetComponent<Renderer>().receiveShadows = false;
    }

    private void InitCapsules()
    {
        for (int i = 0; i < 100; i++) {
            GameObject agent = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            agent.name = "Agent" + i;
            agent.transform.localPosition = new Vector3(Rand(50), 0, Rand(50));
            GameObject.Destroy(agent.GetComponent<Collider>());
            agent.GetComponent<Renderer>().material.color = Random.value < 0.5 ? Color.red : Color.blue;
        }
    }

    private int Rand(int max)
    {
        return Mathf.FloorToInt(Random.value * max);
    }
}
