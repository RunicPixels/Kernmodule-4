using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerListWidget : NetworkBehaviour {

    public PlayerCard playerCardPrefab;
    public LocalPlayerCard localPlayerCardPrefab;
    public PlayerList playerList;

    private int currentDistance = 0;
    public int DISTANCE = Screen.height / 10;

    private List<PlayerCard> cardList;

    private void Start() {
        cardList = new List<PlayerCard>();
        PlayerList.OnPlayerAdded += InstantiateNewCard;
        PlayerList.OnPlayerRemoved += RemoveCard;
        playerList = UnityEngine.Networking.NetworkManager.singleton.gameObject.GetComponent<PlayerList>();
    }

    private void InstantiateNewCard(Player player) {
        PlayerCard card;
        //Debug.Log(Player.LocalPlayer);
        if (player.isLocalPlayer) {
            //Debug.Log("Instancing local player");
            card = Instantiate(localPlayerCardPrefab, transform);
        }
        else
            card = Instantiate(playerCardPrefab, transform);

        card.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition - new Vector2(0, -Screen.height / 3 + currentDistance);
        currentDistance += DISTANCE;
        //card.transform.SetParent(transform);
        cardList.Add(card);
        card.Init(player);
    }

    private void RemoveCard(int id) {
        Destroy(cardList[id].gameObject);
        cardList.RemoveAt(id);
    }

    private void OnDestroy() {
        PlayerList.OnPlayerAdded -= InstantiateNewCard;
        PlayerList.OnPlayerRemoved -= RemoveCard;
    }

    [Command]
    public void CmdDoLoad() {
        foreach(PlayerCard card in cardList) {
            card.Load();
            Debug.Log("Loading Card: " + card);
        }
    }
}
