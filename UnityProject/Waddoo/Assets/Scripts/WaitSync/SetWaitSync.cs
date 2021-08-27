using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWaitSync : MonoBehaviour {

    public ButtonMoveParameter button;

    public void SetupWaitSync() {
        foreach (Player player in PlayerList.Instance.Players) {
            SetWaitSyncData(player);
        }
        //SyncVars();
        StartCoroutine(VerifyAllPlayers());
    }

    public virtual void SyncVars() { }

    public IEnumerator VerifyAllPlayers() {
        while(CheckAllPlayersReady() == false) {
            SyncVars();
            
            yield return null;
        }
        if (Player.LocalPlayer.isServer) {
            Player.LocalPlayer.CmdNextScene();
        }
    }

    public virtual void SetWaitSyncData(Player player) {
        player.WaitSync.SetupNewScene(button, WaitSync.SyncType.Default);
    }

    protected virtual bool CheckAllPlayersReady() {
        return true;
    }

}
