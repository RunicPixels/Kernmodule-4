using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Big5Exit : MonoBehaviour {
    public GameProgress.Trait trait;
    
    [Range(-1,1)]
    public int value;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other) {
        if(trait == GameProgress.Trait.Extraversion) {
            GameProgress.extraversion = value;
        }
        SceneManager.LoadScene(0);
    }
}
