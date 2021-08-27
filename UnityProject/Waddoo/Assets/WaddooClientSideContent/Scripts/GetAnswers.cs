using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetAnswers : MonoBehaviour {
    public Image[] frames;
    public Image portrait;
    public Text text;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void GetAnswer() {

    }

    public void SetText(string answerGiven) {
        text.text = answerGiven;
    }

    public void SetImage(Image image) {
        portrait.sprite = image.sprite;
    }
    public void SetFrameColor(Color color) {
        foreach(Image frame in frames) {
            frame.color = color;
        }
    }
    public Sprite GetSprite() {
        return portrait.sprite;
    }
}
