
using UnityEngine;

public class Utils {

    public static int RandomInt (int max) {
        return Mathf.FloorToInt(Random.value * max);
    }

}
