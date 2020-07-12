
using UnityEngine;

public class Materials {

    public static readonly Material GROUND;

    public static readonly Material SUGAR;

    public static readonly Material DEFAULT;

    public static readonly Material LOW_METABOLISM;
    public static readonly Material MEDIUM_METABOLISM;
    public static readonly Material HIGH_METABOLISM;

    public static readonly Material MALE;
    public static readonly Material FEMALE;

    public static readonly Material LOW_VISION;
    public static readonly Material MEDIUM_VISION;
    public static readonly Material HIGH_VISION;

    static Materials () {
        GROUND = new Material(Shaders.Legacy.DIFFUSE) {
            color = Color.white
        };

        SUGAR = new Material(Shaders.Legacy.DIFFUSE) {
            color = Color.yellow
        };

        DEFAULT = new Material(Shaders.Legacy.DIFFUSE) {
            color = Color.red
        };

        MALE = new Material(Shaders.Legacy.DIFFUSE) {
            color = Color.red
        };
        FEMALE = new Material(Shaders.Legacy.DIFFUSE) {
            color = Color.blue
        };

        LOW_VISION = new Material(Shaders.Legacy.DIFFUSE) {
            color = Color.red
        };
        MEDIUM_VISION = new Material(Shaders.Legacy.DIFFUSE) {
            color = new Color(0.5f, 0, 0.5f, 1) // purple
        };
        HIGH_VISION = new Material(Shaders.Legacy.DIFFUSE) {
            color = Color.blue
        };

        LOW_METABOLISM = new Material(Shaders.Legacy.DIFFUSE) {
            color = Color.blue
        };
        MEDIUM_METABOLISM = new Material(Shaders.Legacy.DIFFUSE) {
            color = new Color(0.5f, 0, 0.5f, 1) // purple
        };
        HIGH_METABOLISM = new Material(Shaders.Legacy.DIFFUSE) {
            color = Color.red
        };
    }

}
