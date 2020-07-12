
public class State {

    public enum ColoringOptions {
        DEFAULT,
        BY_METABOLISM,
        BY_SEX,
        BY_VISION
    }

    public static float DELTA_TIME = 0;
    public static bool PAUSED = true;
    public static bool DONE = false;
    public static int STEPS_PER_SECOND = 4;
    public static ColoringOptions COLORING_OPTION = ColoringOptions.DEFAULT;

}
