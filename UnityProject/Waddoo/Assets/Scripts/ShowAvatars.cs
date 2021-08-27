using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAvatars : MonoBehaviour {

	private int currentDistance = 0;
	public const int DISTANCE = 20;
	
	public GameObject avatarPrefab;
	public Transform avatarContainer;
	
	public void DoShowAvatars(){
		foreach (Player player in PlayerList.Instance.Players){
			if (!player.isLocalPlayer) {
				SpawnAvatar(player);
			}
		}
	}
	
	public void SpawnAvatar(Player player){
		GameObject instance;
        instance = Instantiate(avatarPrefab, avatarContainer);

        GameObject instanceChild = instance.transform.Find("OnderAvatar").gameObject;
        instanceChild.GetComponent<AvatarData>().PlayerID = player.PlayerID;
        instanceChild.GetComponentInChildren<Text>().text = player.Name;
        instanceChild.GetComponent<Image>().sprite = AvatarConverter.Instance.GetAvatarByID(player.PlayerAvatarID).Sprite;

        //TD: instanceChild.GetComponent<Text> set text;
        instance.transform.localPosition = instance.transform.localPosition + new Vector3(currentDistance, 0, 0);
        currentDistance += Mathf.CeilToInt(instanceChild.GetComponent<RectTransform>().rect.width + DISTANCE);
    }

    public void Reset() {
        currentDistance = 0;
    }
}