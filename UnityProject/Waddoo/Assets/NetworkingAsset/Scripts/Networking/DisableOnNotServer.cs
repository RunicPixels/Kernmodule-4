using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DisableOnNotServer: MonoBehaviour {
    public Button button;
    private void Start() {
		//Debug.Log(NetworkManager.singleton.numPlayers);
        gameObject.SetActive(NetworkManager.singleton.numPlayers == 0);
    }

    public void Update() {
        if (Player.LocalPlayer != null) {
            if (!Player.LocalPlayer.isServer) {
                button.interactable = false;
            }
            else {
                button.interactable = true;
            }
        }
    }
}
