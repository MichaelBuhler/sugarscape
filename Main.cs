
using UnityEngine;

public class Main : MonoBehaviour {

    private float elaspedTime = 0;

    void Awake () {
        Simulation.Init();
        Simulation.Render();
    }

    void Update () {
        this.elaspedTime += Time.deltaTime;
        float secondsPerStep = 1.0f / Simulation.Parameters.STEPS_PER_SECOND;
        for ( int i = (int) ( this.elaspedTime * secondsPerStep ) ; i > 0 ; i-- ) {
            Simulation.Step();
            Simulation.Render();
            this.elaspedTime -= secondsPerStep;
        }
    }
}
