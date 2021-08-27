using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManager : MonoBehaviour {

    public int scenariosToRun = 10;

    private static ScenarioManager instance;
    public static ScenarioManager Instance { get { return instance; } }

    public ScenarioObject[] scenarios;

    public void Awake() {
        instance = this;
    }

    public ScenarioObject GetScenarioObjectByIndex(int index) {
        if(index >= scenarios.Length || index >= scenariosToRun) {
            return null;
        }
        return scenarios[index];
    }
}
