
using System.Collections.Generic;

using UnityEngine;

public class Location {

    public readonly int x;
    public readonly int y;
    public readonly int capacity;

    public int sugar { get; private set; }
    
    public Location north { get; private set; }
    public Location south { get; private set; }
    public Location east { get; private set; }
    public Location west { get; private set; }

    public GameObject gameObject;

    public Agent agent;

    public Location (int x, int y, int capacity) {
        this.x = x;
        this.y = y;
        this.capacity = capacity;

        sugar = capacity;

        InitGameObject();
    }

    public void Destroy () {
        Object.Destroy(gameObject);
    }

    public void SetNeighbors (
        Location north,
        Location south,
        Location east,
        Location west
    ) {
        this.north = north;
        this.south = south;
        this.east = east;
        this.west = west;
    }

    public void Step () {
        sugar = Mathf.Min(sugar + Simulation.Parameters.SUGAR_GROWTH_RATE, capacity);
    }

    public void Render () {
        gameObject.transform.localScale = Mathf.Sqrt(sugar) * Vector3.one / 25;
    }

    public int Harvest () {
        int sugar = this.sugar;
        this.sugar = 0;
        return sugar;
    }

    public List<Location> GetNeighboringLocations () {
        List<Location> locations = new List<Location>();
        locations.Add(north);
        locations.Add(south);
        locations.Add(east);
        locations.Add(west);
        return locations;
    }

    public List<List<Location>> GetAllLocationsInSight (int distance) {
        List<List<Location>> allLocations = new List<List<Location>>();
        allLocations.Add(GetNorthernLocations(distance));
        allLocations.Add(GetSouthernLocations(distance));
        allLocations.Add(GetEasternLocations(distance));
        allLocations.Add(GetWesternLocations(distance));
        return allLocations;
    }

    private List<Location> GetNorthernLocations (int distance) {
        List<Location> locations = new List<Location>();
        Location that = this;
        do {
            locations.Add(that.north);
            that = that.north;
        } while ( --distance > 0 );
        return locations;
    }

    private List<Location> GetSouthernLocations (int distance) {
        List<Location> locations = new List<Location>();
        Location that = this;
        do {
            locations.Add(that.south);
            that = that.south;
        } while ( --distance > 0 );
        return locations;
    }

    private List<Location> GetEasternLocations (int distance) {
        List<Location> locations = new List<Location>();
        Location that = this;
        do {
            locations.Add(that.east);
            that = that.east;
        } while ( --distance > 0 );
        return locations;
    }

    private List<Location> GetWesternLocations (int distance) {
        List<Location> locations = new List<Location>();
        Location that = this;
        do {
            locations.Add(that.west);
            that = that.west;
        } while ( --distance > 0 );
        return locations;
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
