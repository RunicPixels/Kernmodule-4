using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitializeNewQuestion : MonoBehaviour {
    public Image scenarioImage;
    public Text scenarioText;

    private bool isFirstTime = true;

    public ButtonMoveParameter move;

    public InputField field;

    public GameObject[] waitScenes;
    public GameObject[] activeScenes;

    public GameObject[] containers;

    public Scene5Resetter resetti;

    public RectTransform endScene;
    public RectTransform currentRectTransform;
    public RectTransform[] questionTransforms;

    public void Awake() {
        SetUpNewScene();
    }

    public void SetUpNewScene() {
        if (ScenarioManager.Instance.GetScenarioObjectByIndex(AnswerList.QuestionID) != null) {
            UpdateImageAndText(ScenarioManager.Instance.GetScenarioObjectByIndex(AnswerList.QuestionID)); // Initialized First Because Question ID will increment after this.
            if (!isFirstTime) {
                UpdateQuestionTransform();
                move.DoMove();
            }
            else {
                isFirstTime = false;
            }
            UpdateQuestionID();
            UpdateActives();
        }
        else {
            UpdateEndSceneTransform();
            UpdateQuestionTransform();
            move.destinationObject = endScene;
            move.DoMove();
        }
    }

    public void UpdateImageAndText(ScenarioObject scenario) {
        scenarioImage.sprite = scenario.sprite;
        scenarioText.text = scenario.scenarioText;
    }

    public void UpdateActives() {
        resetti.DoReset();
        field.text = "";
        foreach(GameObject container in containers) {
            foreach(Transform child in container.transform) {
                Destroy(child.gameObject);
            }
        }
        foreach(GameObject active in activeScenes) {
            active.SetActive(true);
        }
        foreach(GameObject wait in waitScenes) {
            wait.SetActive(false);
        }
    }

    public void UpdateQuestionID() {
        AnswerList.QuestionID += 1;
    }

    public void UpdateQuestionTransform() {
        //foreach (Player player in PlayerList.Instance.Players) {
        //    player.WaitSync.CmdPlayerWaitSyncReady(false);
        //}
        for (int i = 0; i < questionTransforms.Length; i++) {
            questionTransforms[i].anchorMin = new Vector2(currentRectTransform.anchorMin.x + i + 1, currentRectTransform.anchorMin.y);
            questionTransforms[i].anchorMax = new Vector2(currentRectTransform.anchorMax.x + i + 1, currentRectTransform.anchorMax.y);
        }
    }
    public void UpdateEndSceneTransform() {
        for (int i = 0; i < questionTransforms.Length; i++) {
            questionTransforms[i].gameObject.SetActive(false);
        }
        endScene.gameObject.SetActive(true);
        endScene.anchorMin = new Vector2(currentRectTransform.anchorMin.x + 1, currentRectTransform.anchorMin.y);
        endScene.anchorMax = new Vector2(currentRectTransform.anchorMax.x + 1, currentRectTransform.anchorMax.y);
    }
}
