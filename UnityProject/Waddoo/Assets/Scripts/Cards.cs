using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Cards : NetworkBehaviour {

    public enum CardType { extraversion, conscientiousness, stability, agreeableness, openness }

    [SyncVar] public int extraversion;
    [SyncVar] public int consciousness;
    [SyncVar] public int stability;
    [SyncVar] public int agreeableness;
    [SyncVar] public int openness;

    public int GetCardByType(CardType card) {
        switch (card) {
            case CardType.extraversion:
                return extraversion;

            case CardType.conscientiousness:
                return consciousness;

            case CardType.stability:
                return stability;

            case CardType.agreeableness:
                return agreeableness;

            case CardType.openness:
                return openness;

            default:
                Debug.Log("No Cardtype specified");
                return -1;
        }

    }
    public static string GetDutchName(CardType card, bool opposite) {
        if(opposite) {
            switch (card) {
                case CardType.extraversion:
                    return "Introvert";

                case CardType.conscientiousness:
                    return "Chaotisch";

                case CardType.stability:
                    return "Turbulent";

                case CardType.agreeableness:
                    return "Volhardend";

                case CardType.openness:
                    return "Gesloten";

                default:
                    Debug.Log("No Cardtype specified");
                    return "";
            }
        }
        else {
            switch (card) {
                case CardType.extraversion:
                    return "Extravert";

                case CardType.conscientiousness:
                    return "Zorgvuldig";

                case CardType.stability:
                    return "Stabiel";

                case CardType.agreeableness:
                    return "Meegaand";

                case CardType.openness:
                    return "Open";

                default:
                    Debug.Log("No Cardtype specified");
                    return "";
            }
        }
    }
    public string ListCardsS(int playerID) {
        return("Cards at player : " + playerID + " - E :" + extraversion + " - O : " + openness + " - A : " + agreeableness + " - S : " + stability + " - C : " + consciousness);
    }

    public void ListCards(int playerID) {
        Debug.Log("Cards at player : " + playerID + " - E :" + extraversion + " - O : " + openness + " - A : " + agreeableness + " - S : " + stability + " - C : " + consciousness);
    }
}
