using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadAvatarByPlayer : NetworkBehaviour {
    public PlayerCard playerCard;

    //private Avatar avatar;
    // Use this for initialization
    void Awake () {
        playerCard.LoadEvent += SetAvatar;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetAvatar(Player player) {
        //Debug.Log("Loaded Avatar from " + player.PlayerAvatarID);
        GetComponent<Image>().sprite = AvatarConverter.Instance.GetAvatarByID(player.PlayerAvatarID).Sprite;
    }

}
