using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerCard : NetworkBehaviour {
    public Player player;
    public new Text name;

    public event Initialize LoadEvent;
    public delegate void Initialize(Player player);

    public void Update() {
        Load();
        name.text = player.Name;
    }

    public void Init(Player player) {
        this.player = player;
        //FindObjectOfType<SetPlayerStats>().Stats = player;
    }

    public void Load() {
        LoadEvent(player);
    }

}
