using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WaitSync : NetworkBehaviour {

    public enum SyncType { ShowAnswers, ValidateAnswers, ValidateBigFive, Default = -1 }
    public SyncType syncType;

    public ButtonMoveParameter button;
    public ShowAnswers showAnswers;
    public CheckAnswers checkAnswers;
    public CheckBig5 checkBig5;
	public InitializeNewQuestion initNewScene;

    [SyncVar] private bool playerWaitSyncReady;
    public bool PlayerWaitSyncReady { get { return playerWaitSyncReady; } }

    [Command]
    public void CmdPlayerWaitSyncReady(bool status) {
        playerWaitSyncReady = status;
    }

    [ClientRpc]
    public void RpcNextScene() {
        foreach (Player player in PlayerList.Instance.Players) {
            player.WaitSync.CmdPlayerWaitSyncReady(false);
        }
        switch (syncType) {
            case SyncType.ShowAnswers:
                showAnswers.DoShowAnswers();
                button.DoMove();
                break;
            case SyncType.ValidateAnswers:
                checkAnswers.DoStuff();
                //button.DoMove();
                break;
			case SyncType.ValidateBigFive:
				initNewScene.SetUpNewScene();
                checkBig5.SaveBig5();
				//button.DoMove();
				break;
            default:
                Debug.Log("No SyncType defined");
                break;
        }
	}
    public void SetupNewScene(ButtonMoveParameter butt, SyncType sync = SyncType.Default) {
        button = butt;
        syncType = sync;
    }

    public void SetupNewScene(ButtonMoveParameter butt, SyncType sync = SyncType.ShowAnswers, ShowAnswers answers = null) {
        button = butt;
        showAnswers = answers;
        syncType = sync;
    }
	
	public void SetupNewScene(ButtonMoveParameter butt, SyncType sync = SyncType.ShowAnswers, InitializeNewQuestion initScene = null, CheckBig5 big5 = null) {
        button = butt;
        initNewScene = initScene;
        syncType = sync;
        checkBig5 = big5;
    }

    public void SetupNewScene(ButtonMoveParameter butt, SyncType sync = SyncType.ValidateAnswers, CheckAnswers answers = null) {
        button = butt;
        checkAnswers = answers;
        syncType = sync;
    }
}
