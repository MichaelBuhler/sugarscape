
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public Text generateButton;
    public Text playButton;

    public Text growth;
    public Text speed;
    public Text step;

    public InputField numberField;

    private void Update () {
        growth.text = Simulation.Parameters.SUGAR_GROWTH_RATE.ToString();
        speed.text = State.STEPS_PER_SECOND.ToString();
        step.text = "Step: " + Simulation.CURRENT_STEP.ToString();
    }

    public void ColorsDefaultToggled (bool value) {
        if ( value ) {
            State.COLORING_OPTION = State.ColoringOptions.DEFAULT;
            Simulation.Render();
        }
    }

    public void ColorsSexToggled (bool value) {
        if ( value ) {
            State.COLORING_OPTION = State.ColoringOptions.BY_SEX;
            Simulation.Render();
        }
    }

    public void FasterButtonClicked () {
        State.STEPS_PER_SECOND = Mathf.Clamp(++State.STEPS_PER_SECOND, 1, 30);
    }

    public void GenerateButtonClicked () {
        generateButton.text = "Generate";
        playButton.text = "Play";
        State.PAUSED = true;
        Simulation.Init();
        Simulation.Render();
    }

    public void LessButtonClicked () {
        Simulation.Parameters.SUGAR_GROWTH_RATE = Mathf.Clamp(--Simulation.Parameters.SUGAR_GROWTH_RATE, 1, 4);
    }

    public void MoreButtonClicked () {
        Simulation.Parameters.SUGAR_GROWTH_RATE = Mathf.Clamp(++Simulation.Parameters.SUGAR_GROWTH_RATE, 1, 4);
    }

    public void NumberFieldChanged (string value) {
        if ( value.Length > 0 ) {
            int num = int.Parse(value);
            if ( num < 0 ) {
                num = 0;
            } else if ( num > 1000 ) {
                num = 1000;
            }
            Simulation.Parameters.INITIAL_NUMBER_OF_AGENTS = num;
            numberField.text = num.ToString();
        } else {
            Simulation.Parameters.INITIAL_NUMBER_OF_AGENTS = 0;
        }
    }

    public void NumberFieldUnfocused (string value) {
        if ( value.Length > 0 ) {
            int num = int.Parse(value);
            if ( num < 0 ) {
                num = 0;
            } else if ( num > 1000 ) {
                num = 1000;
            }
            Simulation.Parameters.INITIAL_NUMBER_OF_AGENTS = num;
            numberField.text = num.ToString();
        } else {
            Simulation.Parameters.INITIAL_NUMBER_OF_AGENTS = 0;
            numberField.text = "0";
        }
    }

    public void PlayButtonClicked () {
        generateButton.text = "Reset";
        if ( State.PAUSED ) {
            State.PAUSED = false;
            playButton.text = "Pause";
            State.DELTA_TIME = 0;
            Simulation.Step();
            Simulation.Render();
        } else {
            State.PAUSED = true;
            playButton.text = "Play";
        }
    }

    public void SlowerButtonClicked () {
        State.STEPS_PER_SECOND = Mathf.Clamp(--State.STEPS_PER_SECOND, 1, 30);
    }

}
