﻿
using UnityEngine;

public class Main : MonoBehaviour {

    private void Start () {
        Simulation.Init();
        Simulation.Render();
    }

    private void Update () {
        if ( State.PAUSED ) {
            return;
        }
        State.DELTA_TIME += Time.deltaTime;
        float secondsPerStep = 1.0f / State.STEPS_PER_SECOND;
        for ( int i = (int) ( State.DELTA_TIME / secondsPerStep ) ; i > 0 ; i-- ) {
            State.DELTA_TIME -= secondsPerStep;
            Simulation.Step();
            Simulation.Render();
        }
    }

}
