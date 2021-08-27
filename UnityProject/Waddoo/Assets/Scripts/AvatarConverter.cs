using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarConverter : MonoBehaviour {
    public static AvatarConverter Instance;

    public List<Avatar> avatars;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public Avatar GetAvatarByID(short ID) {
        return avatars[ID];
    }
}
