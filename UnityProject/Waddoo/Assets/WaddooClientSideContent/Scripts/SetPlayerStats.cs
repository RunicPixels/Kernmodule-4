using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPlayerStats : MonoBehaviour {

    private Avatar avatar;
    public Text nameText;

    public void SetAvatar() {
        avatar = FindObjectOfType<SelectAvatar>().GetAvatar();
    }

    public void DoSetPlayerStats() {
        SetThePlayerStats();
    }

    public void SetThePlayerStats() {
        // yield return until data is received.
        //stats.SetPlayerStats(selectAvatar.selectedAvatar.GetComponent<Image>(), nameText.text); # LEGACY IMPLEMENTATION FOR REFERENCE
        
        SetAvatar();

        // DELAY UNTIL ALL STATS ARE RECEIVED

        // LOCAL INTEGRATION (NEEDS NETWORKING)
        Player.LocalPlayer.CmdUpdateName(nameText.text);
        Player.LocalPlayer.CmdUpdateAvatar(avatar.Id);
    }
}
