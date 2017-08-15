using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour {

	public Button resumeBTN;
	public Button restartBTN;
	public Button quitBTN;
	public Button quitDesktopBTN;
	public Button quit2BTN;
	public Button dontQuitBTN;
	public Image Quit2;
	public Text quit2Tx, desktop, noQuit, youSure;
	//public Button bunkBTN;

	// Use this for initialization
	void Start () {
		resumeBTN = resumeBTN.GetComponent<Button>();
		restartBTN = restartBTN.GetComponent<Button>();
		quitBTN = quitBTN.GetComponent<Button>();
		quitDesktopBTN = quitDesktopBTN.GetComponent<Button>();
		quit2BTN = quit2BTN.GetComponent<Button>();
		dontQuitBTN = dontQuitBTN.GetComponent<Button>();
		//bunkBTN = bunkBTN.GetComponent<Button>();
		Quit2.enabled = false;
		quit2Tx.enabled = false;
		desktop.enabled = false;
		noQuit.enabled = false;
		youSure.enabled = false;
	}

	public void quitOne()
	{
		Quit2.enabled = true;
		quit2Tx.enabled = true;
		desktop.enabled = true;
		noQuit.enabled = true;
		youSure.enabled = true;
	}

	public void restart()
	{
		Application.LoadLevel("Prototype");
	}

	public void quitDesktop()
	{
		Application.Quit();
	}

	public void dontQuit()
	{
		Quit2.enabled = false;
		quit2Tx.enabled = false;
		desktop.enabled = false;
		noQuit.enabled = false;
		youSure.enabled = false;
	}

	public void quitTwo()
	{
		Application.LoadLevel("MainMenu");
	}
}
