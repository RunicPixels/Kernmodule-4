using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Networking;

public class SelectAvatar : MonoBehaviour {
    private Avatar selectedAvatar;
    public GameObject highlight;
	public GameObject networkManager;
	private List<Player> playerList;
	private Player localPlayer;

    // Use this for initialization
    private void Start () {
        selectedAvatar = GetComponentInChildren<Avatar>();
        HighlightSelected();

    }
    public void SetAvatar(Avatar current) {
		selectedAvatar = current;
        HighlightSelected();

		playerList = networkManager.GetComponent<PlayerList>().Players;
		
		foreach(Player player in playerList){
			if (player.gameObject.GetComponent<NetworkIdentity>().isLocalPlayer){
				localPlayer = player;
			}
		}
		
		localPlayer.CmdUpdateAvatar(selectedAvatar.Id);

        //Debug.Log("Selected Avatar with ID : " + selectedAvatar.Id);
    }

    public void HighlightSelected() {
        highlight.transform.position = selectedAvatar.transform.position;
    }

    public Avatar GetAvatar() {
        //Debug.Log("Sending avatar" + selectedAvatar.Id + " to network.");
        return selectedAvatar;
    }

}
