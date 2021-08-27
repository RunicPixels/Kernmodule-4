using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableContinueButtonCards : MonoBehaviour {

	public GameObject AnswerContainer;
    private Button butt;
	
	// Use this for initialization
	void Start () {
        butt = GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {

		if(CheckAllCells() == true) {
            butt.interactable = true;
            //buttonText.color = Color.gray;
        }
        else {
            butt.interactable = false;
            //buttonText.color = Color.black;
        }
	}

    bool CheckAllCells() {
        foreach (Transform child in AnswerContainer.transform) {
			DragAndDropCell cell = child.GetComponentInChildren<DragAndDropCell>();
            if (cell.GetItem() == null) {
                return false;
            }
        }
        return true;
    }
}
