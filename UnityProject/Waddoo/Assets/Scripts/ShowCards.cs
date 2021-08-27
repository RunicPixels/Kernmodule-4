using RotaryHeart.Lib.SerializableDictionary;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCards : MonoBehaviour {
    public CardDictionary sprites;
    public CardDictionary oppositeSprites;

    public GameObject layoutVertical;

    public GameObject cardPrefab;
    public RectTransform cardContainer;

    private const int BASEHEIGHT = 300;
    public int verticalCardDistance = 20;

    public void SetupCards() {
        int hDistance = 0;
        foreach(Cards.CardType card in Enum.GetValues(typeof(Cards.CardType))) {
            DoShowCards(card, Player.LocalPlayer.cards.GetCardByType(card), hDistance);
        }
    }

    public void DoShowCards(Cards.CardType cardType, int amount, int horizontalPosition) {
        GameObject container = Instantiate<GameObject>(layoutVertical, cardContainer);
        Big5Layout layout = container.GetComponent<Big5Layout>();
        int vDistance = verticalCardDistance;
        int verticalPostion = 0;
        bool opposite = false;
        if (amount < 0) {
            amount *= -1;
            opposite = true;
        }

        layout.big5Text.text = Cards.GetDutchName(cardType, opposite);
        container.gameObject.name = "Card : " + Cards.GetDutchName(cardType,opposite) + " container";
        layout.amountText.text = "" + amount;

        for (int i = 0; i< amount; i++) {
            GameObject instance = Instantiate<GameObject>(cardPrefab, container.transform);
            RectTransform instanceTransform = instance.GetComponent<RectTransform>();
            instanceTransform.anchoredPosition = cardContainer.anchoredPosition + new Vector2(-horizontalPosition, verticalPostion - BASEHEIGHT);
            verticalPostion -= vDistance;
            Image cardSprite = instance.GetComponent<Image>();
            if (opposite) {
                cardSprite.sprite = oppositeSprites[cardType];
            }
            else {
                cardSprite.sprite = sprites[cardType];
            }
        }
    }


}

[Serializable]
public class CardDictionary : SerializableDictionaryBase<Cards.CardType, Sprite> { }

