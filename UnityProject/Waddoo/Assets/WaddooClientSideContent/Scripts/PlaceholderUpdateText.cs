using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class PlaceholderUpdateText : MonoBehaviour {
    public Text input;
    public Text output;
    private UnityAction action;
	// Use this for initialization
	void Start () {
        action += UpdateText;
        GetComponent<Button>().onClick.AddListener(action);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void UpdateText() {
        output.text = input.text;
    }
}
