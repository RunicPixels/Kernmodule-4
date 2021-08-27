using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWaitSyncShowAnswers : SetWaitSync {
    public ShowAnswers showAnswers;

    public override void SetWaitSyncData(Player player) {
        player.WaitSync.SetupNewScene(button, WaitSync.SyncType.ShowAnswers, showAnswers);
    }

    protected override bool CheckAllPlayersReady() {
        return PlayerList.Instance.CheckAnswers(AnswerList.QuestionID);
    }
}


