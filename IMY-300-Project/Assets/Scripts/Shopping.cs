using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shopping : MonoBehaviour {

	public Button foodBTN;
	public Button energyBTN;
	public GameObject player;

	// Use this for initialization
	void Start () {
		foodBTN = foodBTN.GetComponent<Button>();
		energyBTN = energyBTN.GetComponent<Button>();
	}
	public void giveFood()
	{
		player.SendMessage("heal", 50);
		player.SendMessage("removeMoney",10);
		Debug.Log("Food bought");
	}

	public void giveCoffee()
	{
		player.SendMessage("giveEnergy", 50);
		player.SendMessage("removeMoney", 10);
		Debug.Log("Coffee bought");
	}
}
