
using UnityEngine;

public class Shaders {

    public static class Legacy {

        public static readonly Shader SIMPLE_LIT;

        static Legacy () {
            SIMPLE_LIT = Shader.Find("Universal Render Pipeline/Simple Lit");
        }

    }

}
