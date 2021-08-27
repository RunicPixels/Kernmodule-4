using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameProgress {
    public enum Trait { Extraversion = 0, Openness = 1} 
    public static int extraversion = 0;


    public static void Awake() {
        extraversion = 0;
    }
}

