using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Answer : NetworkBehaviour {

    // Contains behaviour related to displaying answers and modifiying answers

	public Text text;
    public int playerID;

	//private DragAndDropCell cell;
	// Use this for initialization
	private void Start () {
		text = GetComponent<Text>();
		//cell = GetComponentInChildren<DragAndDropCell>();
	}
	
	// Update is called once per frame
	private void Update () {
		
	}
}
