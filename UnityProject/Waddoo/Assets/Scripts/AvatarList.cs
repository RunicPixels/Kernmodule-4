using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarList : MonoBehaviour {
    public Avatar[] avatars;
    // Use this for initialization
    void Start () {
        SetIDs();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetIDs() {
        avatars = GetComponentsInChildren<Avatar>();
        for (short i = 0; i < avatars.Length; i++) {
            avatars[i].Id = i;
        }
    }

    public Sprite GetSpriteByID(short id) {
        return avatars[id].Sprite;
    }

}
