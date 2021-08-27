using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableContinueButton : MonoBehaviour {
    public Text placeholderText;
    private Button butt;
	// Use this for initialization
	void Start () {
        butt = GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		if(placeholderText.enabled) {
            butt.interactable = false;
            //buttonText.color = Color.gray;
        }
        else {
            butt.interactable = true;
            //buttonText.color = Color.black;
        }
	}
}
