using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Player : NetworkBehaviour {

    public static Player LocalPlayer { get; private set; }

    [SyncVar, SerializeField] private new string name;
    public string Name { get { return name; } }

    [SyncVar, SerializeField] private int playerID;
    public int PlayerID { get { return playerID; } }

    [SyncVar, SerializeField] private short playerAvatarID;
    public short PlayerAvatarID { get { return playerAvatarID; } }
	
	[SyncVar, SerializeField] private int score;
	public int Score { get { return score; } }

    public PlayerList PlayerList { get; private set; }

    // Content Related to Answers

    private AnswerList answerList;
    public AnswerList AnswerList { get { return answerList; } }


    private WaitSync waitSync;
    public WaitSync WaitSync { get { return waitSync; } }

    // Content Related to Big 5

    public Cards cards;

    //[SerializeField] private SceneAsset gameOverScene; # REMOVED BECAUSE THERE IS NO "GAME OVER"IN WADDOO

    public void Start() {
        if (GetComponent<Cards>() != null) {
            cards = GetComponent<Cards>();
        }
        else {
            cards = gameObject.AddComponent<Cards>();
        }


        if (GetComponent<AnswerList>() != null) {
            answerList = GetComponent<AnswerList>();
        }
        else {
            answerList = gameObject.AddComponent<AnswerList>();
        }

        if (GetComponent<WaitSync>() != null) {
            waitSync = GetComponent<WaitSync>();
        }
        else {
            waitSync = gameObject.AddComponent<WaitSync>();
        }

        transform.SetParent(NetworkManager.singleton.transform);
        PlayerList = NetworkManager.singleton.transform.GetComponent<PlayerList>();
        playerID = PlayerList.Players.Count;
        PlayerList.AddPlayer(this);
        if (isLocalPlayer) {
            LocalPlayer = this;
            gameObject.name += "(LOCAL)";
        }
    }

    [Command]
    public void CmdUpdateName(string name) {
        this.name = name;
    }

    [Command]
    public void CmdUpdateAvatar(short spriteID) {
        playerAvatarID = spriteID;
    }

    [Command]
    public void CmdUpdateScore(int scoreToAdd) {
        score += scoreToAdd;
    }

    [Command]
    public void CmdNextScene() {
        waitSync.RpcNextScene();
    }

    [Command]
    public void CmdAddCardByType(Cards.CardType card, bool isOpposite, int playerID) {

        Player player = Player.LocalPlayer;
        foreach (Player p in PlayerList.Instance.Players) {
            if (p.PlayerID == playerID) {
                player = p;
            }
        }

        Debug.Log("pid: " + playerID + " and " + player.PlayerID + " PlayerList length: " + PlayerList.Instance.Players.Count);
        int opposite = 1;
        if (isOpposite) {
            opposite = -1;
        }

        switch (card) {
            case Cards.CardType.extraversion:
                player.cards.extraversion += opposite;
                break;

            case Cards.CardType.conscientiousness:
                player.cards.consciousness += opposite;
                break;

            case Cards.CardType.stability:
                player.cards.stability += opposite;
                break;

            case Cards.CardType.agreeableness:
                player.cards.agreeableness += opposite;
                break;

            case Cards.CardType.openness:
                player.cards.openness += opposite;
                break;

            default:
                Debug.Log("No Cardtype specified");
                break;

        }
    }


    public void DisconnectFromNetwork() {
        NetworkManager.singleton.StopClient();
        NetworkManager.singleton.StopHost();
        NetworkManager.singleton.StopMatchMaker();
        NetworkServer.Reset();

        Destroy(gameObject);
        Destroy(NetworkManager.singleton.gameObject);
    }
}
