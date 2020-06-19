
using UnityEngine;

public class Environment {

    public Location[,] locations;

    public GameObject gameObject;

    public Environment () {
        InitLocations();
        InitGameObject();
    }

    public void Render () {
        for ( int y = 0 ; y < locations.GetLength(0) ; y++ ) {
            for ( int x = 0 ; x < locations.GetLength(1) ; x++ ) {
                locations[y, x].Render();
            }
        }
    }

    public Location GetUnoccupiedLocation () {
        while ( true ) {
            Location location = locations[Utils.RandomInt(locations.GetLength(0)), Utils.RandomInt(locations.GetLength(1))];
            if ( location.agent == null ) {
                return location;
            }
        }
    }

    private void InitLocations () {
        locations = new Location[Utils.SUGAR_CAPACITIES.GetLength(0), Utils.SUGAR_CAPACITIES.GetLength(1)];
        int width = 50;
        int height = 50;
        for ( int x = 0 ; x < width ; x++ ) {
            for ( int y = 0 ; y < height ; y++ ) {
                locations[x, y] = new Location(x, y, Utils.SUGAR_CAPACITIES[y, x]);
            }
        }
    }

    private void InitGameObject () {
        gameObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
        gameObject.name = "Ground";
        gameObject.transform.localScale *= 5;
        gameObject.transform.localPosition = new Vector3(24.5f, -1.05f, 24.5f);

        Object.Destroy(gameObject.GetComponent<Collider>());

        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.receiveShadows = false;
        renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        renderer.sharedMaterial = Materials.GROUND;
    }

}
