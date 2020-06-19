
using UnityEngine;

public class Shaders {

    public static class Legacy {

        public static readonly Shader DIFFUSE;

        static Legacy () {
            DIFFUSE = Shader.Find("Legacy Shaders/Diffuse");
        }

    }

}
