using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene5Resetter : MonoBehaviour {
    public ShowAnswers[] answers;
    public ShowAvatars avatars;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DoReset() {
		foreach (ShowAnswers answer in answers){
			answer.Reset();
		}
        avatars.Reset();
    }
}
