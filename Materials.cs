
using UnityEngine;

public class Materials {

    public static readonly Material sugarscape;

    public static readonly Material male;
    public static readonly Material female;

    static Materials () {
        sugarscape = new Material(Shaders.Legacy.diffuse) {
            color = Color.white
        };

        male = new Material(Shaders.Legacy.diffuse) {
            color = Color.red
        };
        female = new Material(Shaders.Legacy.diffuse) {
            color = Color.blue
        };
    }

}
