using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuScript : MonoBehaviour
{
  public Button startBTN;
  public Button exitBTN;
  public Button charBTN;

  void Start()
  {
    exitBTN = exitBTN.GetComponent<Button>();
    startBTN = startBTN.GetComponent<Button>();
    charBTN = charBTN.GetComponent<Button>();
  }

  public void exitPress()
  {
    Application.Quit();
  }

  public void startPress()
  {
    Application.LoadLevel("Prototype");
  }

  public void charPress()
  {
    Application.LoadLevel("CharacterMessAround");
  }
}
