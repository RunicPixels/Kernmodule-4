using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Avatar : NetworkBehaviour {
    [SerializeField, SyncVar]
    private short id;

    private Sprite sprite;

    public short Id {
        get {
            return id;
        }

        set {
            id = value;
        }
    }

    public Sprite Sprite {
        get {
            return sprite;
        }

        set {
            sprite = value;
        }
    }

    // Use this for initialization
    void Start () {
        // PROBABLY NEEDS A MORE DYNAMIC ASSIGNMENT IF AVATARS ARE TO BE GENERATED
        sprite = GetComponent<Image>().sprite;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
