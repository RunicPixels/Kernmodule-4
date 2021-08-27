using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ShowAnswers : NetworkBehaviour {
    private PlayerList list;
    public Answer answerPrefab;
    public Transform answerContainer;

    private int currentDistance = 0;
    public const int DISTANCE = 248;

    public void DoShowAnswers() {
        list = PlayerList.Instance;
		List<Player> players = new List<Player>(list.Players);
		players.Shuffle();
        foreach (Player player in players) {
            if (CheckQuestionID(player, AnswerList.QuestionID) && !player.isLocalPlayer) {
                SpawnAnswer(answerPrefab, player, AnswerList.QuestionID);
            }
        }
    }

    private bool CheckQuestionID(Player player, int id) {
        if (player.AnswerList.GetAnswerByQuestionID(id).questionID == id) {
            return true;
        }
        else {
            return false;
        }
    }

    public void SpawnAnswer(Answer prefab, Player player, int questionID) {
        Answer instance;
        instance = Instantiate(prefab, answerContainer);
        instance.playerID = player.PlayerID;

        Text answerText = instance.GetComponent<Text>();
        answerText.text = player.AnswerList.GetReponse(questionID);
        answerText.rectTransform.anchoredPosition = answerText.rectTransform.anchoredPosition   - new Vector2(0,currentDistance);
        currentDistance += DISTANCE;
    }

    public void Reset() {
        currentDistance = 0;
    }
}

//Shuffle any (I)List with an extension method based on the Fisher-Yates shuffle:
static class MyExtensions
{
	//private static Random rng = new Random();
	public static void Shuffle<T>(this IList<T> list)
	{
		int n = list.Count;
		while (n > 1) {
			n--;
			int k = Random.Range(0, n + 1);
			T value = list[k];
			list[k] = list[n];
			list[n] = value;
		}
	}
}
