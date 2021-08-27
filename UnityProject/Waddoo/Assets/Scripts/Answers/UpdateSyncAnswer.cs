using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Networking;

public class UpdateSyncAnswer : NetworkBehaviour {

    [SyncVar, SerializeField] private string answer;
    public string Answer { get { return answer; } }

    public Text input;

    public void CompleteText() {
        answer = input.text;
        Player.LocalPlayer.AnswerList.CmdAddAnswer(answer, AnswerList.QuestionID);
    }
}
