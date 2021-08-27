using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckAnswers : MonoBehaviour {

    public GameObject activeScene, waitScene, answerContainer, waitButton, resetButton;

    public Color rightColor, wrongColor;

    public void DoStuff() {
        activeScene.SetActive(true);
        waitScene.SetActive(false);

        waitButton.SetActive(false);
        resetButton.SetActive(true);

        int scoreToAdd = 0;
        foreach(Transform child in answerContainer.transform) {
            // Logic to see if answer is right here
            Answer answer = child.gameObject.GetComponent<Answer>();
            AvatarData avatar = child.gameObject.GetComponentInChildren<AvatarData>();

            Color currentColor = rightColor;
            if (answer.playerID != avatar.PlayerID) {
                currentColor = wrongColor;
            } else {
                scoreToAdd++;
			}
			
            foreach (Image image in child.GetComponentsInChildren<Image>()) {
                if (image.name == "frame") {
                    image.color = currentColor;
                }
            }
        }
        
        Player.LocalPlayer.CmdUpdateScore(scoreToAdd);
    }
}
