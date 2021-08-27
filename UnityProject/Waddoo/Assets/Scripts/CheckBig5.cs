using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBig5 : MonoBehaviour {

    public GameObject big5AnswerContainer;


    public void SaveBig5() {

        foreach (Transform child in big5AnswerContainer.transform) {
            // Logic to see if answer is right here

            Cards.CardType type;

            bool opposite = false;
            Answer answer = child.gameObject.GetComponent<Answer>();
            Big5Data big5Data = child.gameObject.GetComponentInChildren<Big5Data>();

            type = big5Data.cardType;
            opposite = big5Data.isOpposite;

            Player.LocalPlayer.CmdAddCardByType(type, opposite,answer.playerID);

            
        }
        foreach (Player player in PlayerList.Instance.Players) {
            player.cards.ListCards(player.PlayerID);
        }

    }

    
}

