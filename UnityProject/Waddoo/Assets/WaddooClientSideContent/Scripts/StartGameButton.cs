using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class StartGameButton : NetworkBehaviour {
    public SmoothScroll panel;
    public RectTransform destinationObject;
    private float destination;
    public float duration = 1;
	
	public GameObject inactiveScene, activeScene;
	
    [Command]
    public void CmdNextScene()
    {
        RpcNextScene();
    }
	
	// Use this for initialization
	void Start () {

	}

	[ClientRpc]
    public void RpcNextScene() {		
		// Move animation
        destination = destinationObject.anchorMin.x;
        panel.DoMove(destination, duration);

        // Stop broadcasting network
        CustomNetworkDiscovery.Instance.StopBroadcasting();
		
		// Set current scene inactive, and activate new scene
		inactiveScene.SetActive(true);
		activeScene.SetActive(true);
    }
}
