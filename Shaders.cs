
using UnityEngine;

public class Shaders {

    public static class Legacy {

        public static readonly Shader diffuse;

        static Legacy () {
            diffuse = Shader.Find("Legacy Shaders/Diffuse");
        }

    }

}
