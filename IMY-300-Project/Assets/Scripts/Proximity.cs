using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Proximity : MonoBehaviour
{
  public float distanceShop1;
  public float distanceRoom;
  public float distanceClass;
  private bool shopOpen;
  private bool classOpen;
  public Text helpText;
  public GameObject shop1;
  public GameObject player;
  public GameObject shop2;
  public GameObject room;
  public GameObject hall;

  public Canvas MainUI;
  public Canvas ShopUI;
  public Canvas LecturesUI;
  public Canvas CellphoneUI;
  // public Image ShopBg;
  // public Image OgMenu;
  // public Image OgPics;
  // public Image PlazaMenu;
  // public Image PlazaPics;
  //
  // public Image classBg;
  // public Image classPics;

  void Start()
  {
    hideShop(4);
    //int daysPassed = player.getdaysPassed();
    hideClassMenu();
  }

  void Update()
  {
    checkDistances();

    if(distanceShop1 <= 2f)
    {
      //Debug.Log("Close Enough");
      helpText.text = "Press E to shop";
      if(Input.GetKeyDown("e"))
      {
        //Debug.Log("Shopping Time");
        showShop(1);
      }
    }

    else if(distanceRoom <= 2f)
    {
      helpText.text = "Press E to sleep";
      if(Input.GetKeyDown("e"))
      {
        Debug.Log("Sleepy Time");
        player.SendMessage("sleep");
        //Debug.Log("Days Passed: " + daysPassed);
      }
    }

    else if(distanceClass <= 5f)
    {
      helpText.text = "Press E to attend class";
      if(Input.GetKeyDown("e"))
      {
        // /Debug.Log("Sleepy Time");
        showClassMenu();
        //Debug.Log("Days Passed: " + daysPassed);
      }
    }

    else
    {
      helpText.text = "";
    }
  }

  public void checkDistances()
  {
    distanceShop1 = Vector3.Distance (player.transform.position, shop1.transform.position);
    distanceRoom = Vector3.Distance (player.transform.position, room.transform.position);
    distanceClass = Vector3.Distance (player.transform.position, hall.transform.position);
    //Debug.Log("Distance to shop: " + distanceShop1);
  }

  public void showShop(int i)
  {
    if(i == 1)
    {
      if(shopOpen == true)
      {
        ShopUI.enabled = false;
        // ShopBg.enabled = false;
        // OgMenu.enabled = false;
        // OgPics.enabled = false;
        shopOpen = false;
      }
      else{
        ShopUI.enabled = true;
        // ShopBg.enabled = true;
        // OgMenu.enabled = true;
        // OgPics.enabled = true;
        shopOpen = true;
      }

    }
  }

  public void hideShop(int i)
  {
    if(i == 4)
    {
      ShopUI.enabled = false;
      // ShopBg.enabled = false;
      // OgMenu.enabled = false;
      // OgPics.enabled = false;

      // PlazaMenu.enabled = false;
      // PlazaPics.enabled = false;
      shopOpen = false;
    }
  }

  public void showClassMenu()
  {
      if(classOpen == true)
      {
        LecturesUI.enabled = false;
        // classBg.enabled = false;
        // classPics.enabled = false;
        LecturesUI.enabled = false;
      }
      else{
        LecturesUI.enabled = true;
        // classBg.enabled = true;
        // classPics.enabled = true;
        classOpen = true;
      }

  }

  public void hideClassMenu()
  {
    LecturesUI.enabled = false;
    // classBg.enabled = false;
    // classPics.enabled = false;
    // classOpen = false;
  }
}
