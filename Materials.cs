
using UnityEngine;

public class Materials {

    public static readonly Material GROUND;

    public static readonly Material SUGAR;

    public static readonly Material MALE;
    public static readonly Material FEMALE;

    static Materials () {
        GROUND = new Material(Shaders.Legacy.DIFFUSE) {
            color = Color.white
        };

        SUGAR = new Material(Shaders.Legacy.DIFFUSE) {
            color = Color.yellow
        };

        MALE = new Material(Shaders.Legacy.DIFFUSE) {
            color = Color.red
        };
        FEMALE = new Material(Shaders.Legacy.DIFFUSE) {
            color = Color.blue
        };
    }

}
