using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Lectures : MonoBehaviour {

	public GameObject player;
	public Button attendBTN;
	public Button napBTN;
	//public Button bunkBTN;

	// Use this for initialization
	void Start () {
		attendBTN = attendBTN.GetComponent<Button>();
		napBTN = napBTN.GetComponent<Button>();
		//bunkBTN = bunkBTN.GetComponent<Button>();
	}

	public void attendClass()
	{
		player.SendMessage("addXP", 100);
		player.SendMessage("removeEnergy", 25);
		Debug.Log("Class attended");
	}
	public void napClass()
	{
		player.SendMessage("giveEnergy", 10);
		player.SendMessage("addXP", 25);
		Debug.Log("Class napped");
	}

	public void skipClass()
	{

	}
}
