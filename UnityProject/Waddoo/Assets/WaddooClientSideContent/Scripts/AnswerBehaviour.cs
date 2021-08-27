using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerBehaviour : MonoBehaviour {
    public DragAndDropCell cell;
    public Text answer;
	// Use this for initialization
	void Start () {
        answer = GetComponent<Text>();
        cell = GetComponentInChildren<DragAndDropCell>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
