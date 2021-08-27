using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetAnswers : MonoBehaviour {
    public AnswerBehaviour[] answers;
    public GetAnswers[] getAnswers;

    public Color rightColor;
    public Color wrongColor;

    public void SetTexts() {
        if(answers.Length != getAnswers.Length) {
            Debug.LogError("Answers not equal to getAnswers length at " + gameObject.name);
            return;
        }
        for(int i = 0; i < getAnswers.Length; i++) {
            getAnswers[i].SetText(answers[i].answer.text);
            getAnswers[i].SetImage(answers[i].cell.GetItem().GetComponent<Image>());
            // TODO : Frame Recoloring ( Check if PlayerList Instance Avatar Stats match Avatar Given )
            // TEMPORARY SOLUTION BELOW : Only Check first instance of playerStats;;

            // UGLY CODE TO FIND AVATAR CONTAINER, PROBABLY SHOULD BE A SINGLETON OR BETTER
            AvatarList list = FindObjectOfType<AvatarList>();


            // LOCAL INTEGRATION (NEEDS NETWORKING)
            if (list.GetSpriteByID(Player.LocalPlayer.PlayerAvatarID) != getAnswers[i].GetSprite()) {
                getAnswers[i].SetFrameColor(wrongColor);
            }
            else {
                getAnswers[i].SetFrameColor(rightColor);
            }
        }
        
    }
}
