
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public Text generateButton;
    public Text playButton;

    public Text growth;
    public Text speed;
    public Text step;

    public InputField endowmentMaxField;
    public InputField endowmentMinField;
    public InputField metabolismMaxField;
    public InputField metabolismMinField;
    public InputField numberField;
    public InputField visionMaxField;
    public InputField visionMinField;

    private void Update () {
        growth.text = Simulation.Parameters.SUGAR_GROWTH_RATE.ToString();
        speed.text = State.STEPS_PER_SECOND.ToString();
        step.text = "Step: " + Simulation.CURRENT_STEP.ToString();
        if ( State.DONE ) {
            playButton.transform.parent.GetComponent<Button>().interactable = false;
            playButton.text = "Done";
        }
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

    public void EndowmentMaxUnfocused (string value) {
        if ( value.Length > 0 ) {
            int num = Mathf.Max(Simulation.Parameters.Endowment.MIN, int.Parse(value));
            Simulation.Parameters.Endowment.MAX = num;
            endowmentMaxField.text = num.ToString();
        } else {
            int num = Simulation.Parameters.Endowment.MIN;
            Simulation.Parameters.Endowment.MAX = num;
            endowmentMaxField.text = num.ToString();
        }
    }

    public void EndowmentMinUnfocused (string value) {
        if ( value.Length > 0 ) {
            int num = Mathf.Clamp(int.Parse(value), 0, Simulation.Parameters.Endowment.MAX);
            Simulation.Parameters.Endowment.MIN = num;
            endowmentMinField.text = num.ToString();
        } else {
            Simulation.Parameters.Endowment.MIN = 0;
            endowmentMinField.text = "0";
        }
    }

    public void FasterButtonClicked () {
        State.STEPS_PER_SECOND = Mathf.Clamp(++State.STEPS_PER_SECOND, 1, 30);
    }

    public void GenerateButtonClicked () {
        generateButton.text = "Generate";
        playButton.transform.parent.GetComponent<Button>().interactable = true;
        playButton.text = "Play";
        State.PAUSED = true;
        State.DONE = false;
        Simulation.Init();
        Simulation.Render();
    }

    public void LessButtonClicked () {
        Simulation.Parameters.SUGAR_GROWTH_RATE = Mathf.Clamp(--Simulation.Parameters.SUGAR_GROWTH_RATE, 1, 4);
    }

    public void MetabolismMaxUnfocused (string value) {
        if ( value.Length > 0 ) {
            int num = Mathf.Max(Simulation.Parameters.Metabolism.MIN, int.Parse(value));
            Simulation.Parameters.Metabolism.MAX = num;
            metabolismMaxField.text = num.ToString();
        } else {
            int num = Simulation.Parameters.Metabolism.MIN;
            Simulation.Parameters.Metabolism.MAX = num;
            metabolismMaxField.text = num.ToString();
        }
    }

    public void MetabolismMinUnfocused (string value) {
        if ( value.Length > 0 ) {
            int num = Mathf.Clamp(int.Parse(value), 0, Simulation.Parameters.Metabolism.MAX);
            Simulation.Parameters.Metabolism.MIN = num;
            metabolismMinField.text = num.ToString();
        } else {
            Simulation.Parameters.Metabolism.MIN = 0;
            metabolismMinField.text = "0";
        }
    }

    public void MoreButtonClicked () {
        Simulation.Parameters.SUGAR_GROWTH_RATE = Mathf.Clamp(++Simulation.Parameters.SUGAR_GROWTH_RATE, 1, 4);
    }

    public void NumberFieldChanged (string value) {
        if ( value.Length > 0 ) {
            int num = Mathf.Min(int.Parse(value), 1000);
            numberField.text = num.ToString();
        }
    }

    public void NumberFieldUnfocused (string value) {
        if ( value.Length > 0 ) {
            int num = Mathf.Clamp(int.Parse(value), 0, 1000);
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

    public void VisionMaxUnfocused (string value) {
        if ( value.Length > 0 ) {
            int num = Mathf.Clamp(int.Parse(value), Simulation.Parameters.Vision.MIN, 50);
            Simulation.Parameters.Vision.MAX = num;
            visionMaxField.text = num.ToString();
        } else {
            int num = Simulation.Parameters.Vision.MIN;
            Simulation.Parameters.Vision.MAX = num;
            visionMaxField.text = num.ToString();
        }
    }

    public void VisionMinUnfocused (string value) {
        if ( value.Length > 0 ) {
            int num = Mathf.Clamp(int.Parse(value), 0, Simulation.Parameters.Vision.MAX);
            Simulation.Parameters.Vision.MIN = num;
            visionMinField.text = num.ToString();
        } else {
            Simulation.Parameters.Vision.MIN = 0;
            visionMinField.text = "0";
        }
    }

}
