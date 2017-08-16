using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
  private int DAYS_IN_SEMESTER = 30;
  private float MAX_HEALTH = 150;
  private float MAX_ENERGY = 200;
  private bool HEon = false;

  private float health;
  private float energy;
  private int XP;
  private int money;
  private int daysPassed;

  public Image HealthImg;
  public Text HealthText;

  public Image EnergyImg;
	public Text EnergyText;

  void Start ()
  {
    if(daysPassed < DAYS_IN_SEMESTER)
    {
      // sunInitialIntensity = sun.intensity;
      health = MAX_HEALTH;
      energy = MAX_ENERGY;
      updateHealthBar();
      updateEnergyBar();
      XP = 1;
      money = 500;

      //hidePhone();
    }
  }

  // Update is called once per frame
  void Update ()
  {
    // Updates the sun's rotation and intensity according to the current time of day.


    updateHealthBar();
    //Debug.Log("Health Updated");

    float ticker = energy/200000;
    removeEnergy(ticker);
    updateEnergyBar();

    // if(Input.GetKeyDown("p"))
    // {
    //   showPhone();
    // }

  }

/*============================== HEALTH/DAMAGE ========================================= */

  private void updateHealthBar()
  {
    float ratio3 = health/MAX_HEALTH;
    float ratio4 = ratio3 * 2.900223f;
    HealthImg.rectTransform.localScale = new Vector3(ratio4, 0.325f, 1);
    HealthText.text = "Health: " + (ratio3*100).ToString("0") + "%";

    //Debug.Log("Health updated");
  }

  public void takeDamage(float damage)
  {
    health -= damage;
    if(health <= 0)
    {
      health = 0;
    }
    updateHealthBar();
    Debug.Log("Damage taken");
  }

  public void heal(float heal)
  {
    health += heal;
    if(health >= MAX_HEALTH)
    {
      health = MAX_HEALTH;
    }
    updateHealthBar();
  }

/*==================================================== ENERGY =======================================*/

  private void updateEnergyBar()
  {
    float ratio1 = energy/MAX_ENERGY;
    float ratio2 = ratio1 * 2.898915f;
		EnergyImg.rectTransform.localScale = new Vector3(ratio2, 0.337f, 1);
		EnergyText.text = "Energy: " + (ratio1*100).ToString("0") + "%";
		//Debug.Log("Health updated");
  }

  public void removeEnergy(float e)
  {
    energy -= e;
    if(energy <= 0)
		{
			energy = 0;
		}
		//Debug.Log("Energy Lost");
    updateEnergyBar();
  }

  public void giveEnergy(float e)
  {
    energy += e;
    if(energy >= MAX_ENERGY)
		{
			energy = MAX_ENERGY;
		}
    updateEnergyBar();
		Debug.Log("Energy Recieved");
  }

/*============================================= MONEY =======================================*/

  public int getMoney()
  {
    return money;
  }

  public void removeMoney(int m)
  {
    money -= m;
    if(money <= 0)
		{
			money = 0;
		}
    Debug.Log("Money Used");
		//Debug.Log("Energy Lost");
    //updateEnergyBar();
  }

  public void giveMoney(int m)
  {
    money += m;
  }

/* ============================================== XP ================================================*/

  public int getXP()
  {
    return XP;
  }

  public void addXP(int x)
  {
    XP += x;
  }
}
