using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMoveParameter : MonoBehaviour {
    public SmoothScroll panel;
    public RectTransform destinationObject;
    private float destination;
    public float duration = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DoMove() {
        destination = destinationObject.anchorMin.x;
        //Debug.Log("Move Button Pressed");
        //Debug.Log(Screen.width.ToString());
        panel.DoMove(destination, duration);
    }

}
