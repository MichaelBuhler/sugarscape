﻿
using System.Collections.Generic;

using UnityEngine;

public class Utils {

    public static int[,] SUGAR_CAPACITIES = new int[,] {
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,2,2,2,2},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,2,2},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,2},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,2,2,2,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,2,2,2,2,2,2,3,3,3,3,3,3,4,4,4,4,4,4,3,3,3,3,3,3,3,2},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,2,2,2,2,2,3,3,3,3,3,3,4,4,4,4,4,4,4,4,4,3,3,3,3,3,3},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,2,2,2,2,2,2,3,3,3,3,3,4,4,4,4,4,4,4,4,4,4,3,3,3,3,3,3},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,2,2,2,2,2,3,3,3,3,3,3,4,4,4,4,4,4,4,4,4,4,4,3,3,3,3,3},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,3,3,3,3,3,4,4,4,4,4,4,4,4,4,4,4,4,3,3,3,3,3},
        {0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,3,3,3,3,3,4,4,4,4,4,4,4,4,4,4,4,4,3,3,3,3,3},
        {0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,3,3,3,3,3,4,4,4,4,4,4,4,4,4,4,4,4,3,3,3,3,3},
        {0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,3,3,3,3,3,4,4,4,4,4,4,4,4,4,4,4,4,3,3,3,3,3},
        {0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,3,3,3,3,3,3,4,4,4,4,4,4,4,4,4,4,4,3,3,3,3,3},
        {0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,3,3,3,3,3,3,4,4,4,4,4,4,4,4,4,4,3,3,3,3,3,3},
        {0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,4,4,4,4,4,4,4,4,3,3,3,3,3,3,2},
        {0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,4,4,4,4,3,3,3,3,3,3,3,3,2},
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,2},
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,2,2},
        {1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,2,2,2},
        {1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,2,2,2,2,2},
        {1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,3,2,2,2,2,2,2,2,2},
        {1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
        {1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,1},
        {1,1,1,2,2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,3,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,1,1},
        {1,1,2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,1,1,1,1},
        {1,1,2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,1,1,1,1,1,1,1},
        {1,2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1},
        {2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,2,2,2,2,2,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1},
        {2,2,2,2,2,3,3,3,3,3,3,3,3,4,4,4,4,3,3,3,3,3,3,3,3,3,2,2,2,2,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        {2,2,2,2,2,3,3,3,3,3,3,4,4,4,4,4,4,4,4,3,3,3,3,3,3,3,2,2,2,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        {2,2,2,2,3,3,3,3,3,3,4,4,4,4,4,4,4,4,4,4,3,3,3,3,3,3,2,2,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
        {2,2,2,2,3,3,3,3,3,4,4,4,4,4,4,4,4,4,4,4,3,3,3,3,3,3,2,2,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0},
        {2,2,2,2,3,3,3,3,3,4,4,4,4,4,4,4,4,4,4,4,4,3,3,3,3,3,2,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0},
        {2,2,2,2,3,3,3,3,3,4,4,4,4,4,4,4,4,4,4,4,4,3,3,3,3,3,2,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0},
        {2,2,2,2,3,3,3,3,3,4,4,4,4,4,4,4,4,4,4,4,4,3,3,3,3,3,2,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0},
        {2,2,2,2,3,3,3,3,3,4,4,4,4,4,4,4,4,4,4,4,4,3,3,3,3,3,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0},
        {2,2,2,2,3,3,3,3,3,4,4,4,4,4,4,4,4,4,4,4,3,3,3,3,3,3,2,2,2,2,2,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0},
        {2,2,2,2,3,3,3,3,3,3,4,4,4,4,4,4,4,4,4,4,3,3,3,3,3,2,2,2,2,2,2,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0},
        {2,2,2,2,3,3,3,3,3,3,4,4,4,4,4,4,4,4,4,3,3,3,3,3,3,2,2,2,2,2,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0},
        {2,2,2,2,2,3,3,3,3,3,3,3,4,4,4,4,4,4,3,3,3,3,3,3,2,2,2,2,2,2,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0},
        {2,2,2,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,2,2,2,2,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0},
        {2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,2,2,2,2,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {1,2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,2,2,2,2,2,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {1,1,2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,2,2,2,2,2,2,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {1,1,2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,2,2,2,2,2,2,2,2,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
    };

    public static int RandomInt (int max) {
        while ( true ) {
            int num = Mathf.FloorToInt(Random.value * max);
            if ( num != max ) {
                return num;
            }
        }
    }

    public static int RandomIntBetween (int min, int max) {
        return RandomInt(max - min + 1) + min;
    }

    public static List<T> Shuffle<T> (List<T> list) {
        List<T> shuffled = new List<T>(list);
        int n = list.Count;
        while ( n > 1 ) {
            n--;
            int k = RandomInt(n + 1);
            T item = shuffled[k];
            shuffled[k] = shuffled[n];
            shuffled[n] = item;
        }
        return shuffled;
    }

}