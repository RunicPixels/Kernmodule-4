using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {
    public bool solo;
    private PlayerList list;
    public GameObject scorePrefab;
    public GameObject winnerPrefab;
    public Transform scoreContainer;

    private int currentDistance;
    public int distance = 240;
    // Use this for initialization

    private void OnEnable() {
        if (!solo) {
            DoShowScore();
        }
    }

    public void DoShowScore () {
        if (solo) {
            SpawnScore(winnerPrefab, Player.LocalPlayer);
        }
        else {
            List<Player> players = new List<Player>(PlayerList.Instance.Players);
            players.Sort((x, y) => x.Score.CompareTo(y.Score));
            players.Reverse();
            Player player = players[0];
            players.RemoveAt(0);

            SpawnScore(winnerPrefab, player);

            foreach (Player currentPlayer in players) {
                SpawnScore(scorePrefab, currentPlayer);
                currentDistance += distance;
            }
        }
    }

    public void SpawnScore(GameObject prefab, Player player) {
        GameObject instance;
        instance = Instantiate(prefab, scoreContainer);
        //instance.playerID = player.PlayerID;

        ScorePrefab scorePrefab = instance.GetComponent<ScorePrefab>();
        scorePrefab.avatar.sprite = AvatarConverter.Instance.GetAvatarByID(player.PlayerAvatarID).Sprite;
        scorePrefab.score.text = player.Score.ToString();
        scorePrefab.naam.text = player.Name;

        if(solo) {
            scorePrefab.context.text = "Jouw score:";
        }
        RectTransform rect = instance.GetComponent<RectTransform>();

        rect.anchoredPosition = rect.anchoredPosition - new Vector2(0, currentDistance);
        
    }



    // Update is called once per frame
    private void Update () {
		
	}
}
