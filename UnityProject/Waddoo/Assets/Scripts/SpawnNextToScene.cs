using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNextToScene : MonoBehaviour {
    public RectTransform currentScene;
    public RectTransform sceneToSpawn;
	// Use this for initialization

	
	// Update is called once per frame
	public void SetAllignment () {
        sceneToSpawn.gameObject.SetActive(true);
        sceneToSpawn.anchorMin = currentScene.anchorMin + new Vector2(1, 0);
        sceneToSpawn.anchorMax = currentScene.anchorMax + new Vector2(1, 0);
    }
}
