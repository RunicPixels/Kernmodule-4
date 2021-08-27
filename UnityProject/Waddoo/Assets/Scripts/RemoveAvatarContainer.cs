using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAvatarContainer : MonoBehaviour {
    public GameObject avatarContainer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RemoveContainers() {
        foreach (Transform child in avatarContainer.transform) {
            Destroy(child.gameObject);
        }
    }
}
