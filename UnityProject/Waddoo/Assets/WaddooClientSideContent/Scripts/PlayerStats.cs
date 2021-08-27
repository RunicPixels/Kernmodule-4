using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    /*/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
     Hey Gijs, als je dit leest, in deze klasse worden individuele stats van spelers opgeslagen, het is dus eigenlijk de bedoeling dat de "Netwerkmanager"
     of de Host een array van individuele PlayerStats krijgt, binnen deze klasse worden dan individuele eigenschappen van de speler bijgehouden
     zoals de avatar en naam.
    *//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public Sprite avatar;
    public string playerName;
    
    
    //Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetPlayerStats(Image image, string nameString) {
        avatar = image.sprite;
        playerName = nameString;
    }

}
