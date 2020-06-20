
using UnityEngine;

public class Environment {

    public Location[,] locations;

    public GameObject gameObject;

    public Environment () {
        InitLocations();
        InitGameObject();
    }

    public void Destroy () {
        for ( int y = 0 ; y < locations.GetLength(0) ; y++ ) {
            for ( int x = 0 ; x < locations.GetLength(1) ; x++ ) {
                locations[y, x].Destroy();
            }
        }
        Object.Destroy(gameObject);
    }

    public void Step () {
        for ( int y = 0 ; y < locations.GetLength(0) ; y++ ) {
            for ( int x = 0 ; x < locations.GetLength(1) ; x++ ) {
                locations[y, x].Step();
            }
        }
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

        int height = locations.GetLength(0);
        int width = locations.GetLength(1);

        for ( int y = 0 ; y < height ; y++ ) {
            for ( int x = 0 ; x < width; x++ ) {
                locations[y, x] = new Location(x, y, Utils.SUGAR_CAPACITIES[y, x]);
            }
        }

        for ( int y = 0 ; y < height ; y++ ) {
            for ( int x = 0 ; x < width ; x++ ) {
                int up = y == 0 ? height - 1 : y - 1;
                int down = ( y + 1 ) % height;
                int left = x == 0 ? width - 1 : x - 1;
                int right = ( x + 1 ) % width;
                locations[y, x].SetNeighbors(
                    locations[up, x],
                    locations[down, x],
                    locations[y, right],
                    locations[y, left]
                );
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
