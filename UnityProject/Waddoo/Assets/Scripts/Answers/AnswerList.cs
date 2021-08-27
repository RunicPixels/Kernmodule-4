using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AnswerList : NetworkBehaviour {
    [Serializable]
    public struct SyncAnswer {
        //public int playerID; // Not valid because good reasons
        public int questionID;
        public string response;
    }

    public class SyncListAnswer : SyncListStruct<SyncAnswer> {
    }

    public SyncListAnswer AnswersList = new SyncListAnswer();

    private static int questionID = 0;

    public static int QuestionID {
        get {
            return questionID;
        }

        set {
            questionID = value;
        }
    }

    public SyncAnswer GetAnswerByQuestionID(int question) {
        foreach(SyncAnswer answer in AnswersList) {
            if (answer.questionID == question) {
                return answer;
            }
        }

        SyncAnswer noAnswer = new SyncAnswer {
            response = ""
        };
        return noAnswer;
    }

    [Command]
    public void CmdAddAnswer(string response, int questionID) {
        SyncAnswer answer = new SyncAnswer();
        answer.response = response;
        answer.questionID = questionID;

        AnswersList.Add(answer);
        //ListAnswers();
    }

    public void ListAnswers() {

    }

    public string GetReponse(int questionID) {
        return GetAnswerByQuestionID(questionID).response;
    }


}
