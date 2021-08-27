using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWaitSyncBigFive : SetWaitSync {
	
	public InitializeNewQuestion initNewScene;
    public CheckBig5 big5;
	
    public override void SetWaitSyncData(Player player) {
        player.WaitSync.SetupNewScene(button, WaitSync.SyncType.ValidateBigFive, initNewScene, big5);
    }

    public override void SyncVars() {
        Player.LocalPlayer.WaitSync.CmdPlayerWaitSyncReady(true);
    }

    protected override bool CheckAllPlayersReady() {
        foreach (Player player in PlayerList.Instance.Players) {
            if (!player.WaitSync.PlayerWaitSyncReady) return false;
        }
        return true;
    }
}

