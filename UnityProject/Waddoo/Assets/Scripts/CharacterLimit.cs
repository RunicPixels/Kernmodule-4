using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterLimit : MonoBehaviour {

    public InputField mainInputField;
    public Text limitText;
    public int length = 24;
    public int lengthBeforeShow = 20;

    // Use this for initialization
    private void Start () {
        mainInputField.characterLimit = length;
        limitText.text = "";
        mainInputField.onValueChanged.AddListener(ValueChange);
    }

    private void ValueChange(string value) {
        int charactersRemaining = (length - value.Length);
        if (value.Length > length - lengthBeforeShow) {
            limitText.text = (charactersRemaining).ToString();
        }
        else {
            limitText.text = "";
        }

        limitText.color = new Color(1f, ((float)charactersRemaining / (float)lengthBeforeShow), 0);
    }
}
