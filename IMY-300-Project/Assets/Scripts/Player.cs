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

  public Animation animator;

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

/*======================================= PHONE HIDE/SHOW ===========================================*/

  // void showPhone()
  // {
  //   // Color c = cellphone.color;
  //   // c.a = 1;
  //   // cellphone.color = c;
  //   // isShowing = !isShowing;
  //   // cellphone.setActive(isShowing);
  //   if(isShowing == true)
  //   {
  //     CellphoneUI.enabled = false;
  //     // cellphone.enabled = false;
  //     // cellScreen.enabled = false;
  //     // cellXP.enabled = false;
  //     // cellHeader.enabled = false;
  //     // cellMoney.enabled = false;
  //     // cellBg.enabled = false;
  //     // cellTime.enabled = false;
  //     // cellDays.enabled = false;
  //     isShowing = false;
  //   }
  //   else{
  //     float currentHour = 24 * currentTimeOfDay;
  //     float currentMinute = 60 * (currentHour - Mathf.Floor(currentHour));
  //     int daysleft = DAYS_IN_SEMESTER - daysPassed;
  //
  //
  //     cellTime.text = currentHour.ToString("0") + ":" + currentMinute.ToString("0");
  //     cellMoney.text = "Money: $" + money;
  //     cellXP.text = "XP: " + XP;
  //     cellDays.text = "Days left: " + daysleft;
  //     CellphoneUI.enabled = true;
  //     // cellphone.enabled = true;
  //     // cellScreen.enabled = true;
  //     // cellXP.enabled = true;
  //     // cellBg.enabled = true;
  //     // cellHeader.enabled = true;
  //     // cellMoney.enabled = true;
  //     // cellTime.enabled = true;
  //     // cellDays.enabled = true;
  //     isShowing = true;
  //   }
  // }
  //
  // void hidePhone()
  // {
  //   // isShowing = !isShowing;
  //   // cellphone.setActive(isShowing);
  //   CellphoneUI.enabled = false;
  //   // cellphone.enabled = false;
  //   // cellScreen.enabled = false;
  //   // cellXP.enabled = false;
  //   // cellMoney.enabled = false;
  //   // cellHeader.enabled = false;
  //   // cellBg.enabled = false;
  //   // cellTime.enabled = false;
  //   // cellDays.enabled = false;
  //   isShowing = false;
  // }

/*====================================================== SUN & TIME ==========================================================*/
// The directional light which we manipulate as our sun.
// public Light sun;
// // public Skybox sky;
//
// // The number of real-world seconds in one full game day.
// // Set this to 86400 for a 24-hour realtime day.
// public float secondsInFullDay = 600;
//
// // The value we use to calculate the current time of day.
// // Goes from 0 (midnight) through 0.25 (sunrise), 0.5 (midday), 0.75 (sunset) to 1 (midnight).
// // We define ourself what value the sunrise sunrise should be etc., but I thought these
// // values fit well. And now much of the script are hardcoded to these values.
// [Range(0,1)]
// public float currentTimeOfDay = 0.23f;
//
// // A multiplier other scripts can use to speed up and slow down the passing of time.
// [HideInInspector]
// public float timeMultiplier = 1f;
//
// // Get the initial intensity of the sun so we remember it.
// float sunInitialIntensity;
//
// void UpdateSun() {
//     // Rotate the sun 360 degrees around the x-axis according to the current time of day.
//     // We subtract 90 degrees from this to make the sun rise at 0.25 instead of 0.
//     // I just found that easier to work with.
//     // The y-axis determines where on the horizon the sun will rise and set.
//     // The z-axis does nothing.
//     sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);
//
//     // The following determines the sun's intensity according to current time of day.
//     // You'll notice I have hardcoded a bunch of values here. They were just the values
//     // I felt worked best. This can obviously be made to be user configurable.
//     // Also with some more clever code you can have different lengths for the day and
//     // night as well.
//
//     // The sun is full intensity during the day.
//     float intensityMultiplier = 1;
//     // Set intensity to 0 during the night night.
//     if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f) {
//       intensityMultiplier = 0;
//     }
//     // Fade in the sun when it rises.
//     else if (currentTimeOfDay <= 0.25f) {
//         // 0.02 is the amount of time between sunrise and the time we start fading out
//         // the intensity (0.25 - 0.23). By dividing 1 by that value we we get get 50.
//         // This tells us that we have to fade in the intensity 50 times faster than the
//         // time is passing to be able to go from 0 to 1 intensity in the same amount of
//         // time as the currentTimeOfDay variable goes from 0.23 to 0.25. That way we get
//         // a perfect fade.
//         intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
//     }
//     // And fade it out when it sets.
//     else if (currentTimeOfDay >= 0.73f) {
//         intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
//     }
//
//     // Multiply the intensity of the sun according to the time of day.
//     sun.intensity = sunInitialIntensity * intensityMultiplier;
//     float exposure = sunInitialIntensity * intensityMultiplier;
//     RenderSettings.skybox.SetFloat("_Exposure", exposure);
//     //Debug.Log("Time: " + currentTimeOfDay);
// }
// // void UpdateSky() {
// //     // Rotate the sun 360 degrees around the x-axis according to the current time of day.
// //     // We subtract 90 degrees from this to make the sun rise at 0.25 instead of 0.
// //     // I just found that easier to work with.
// //     // The y-axis determines where on the horizon the sun will rise and set.
// //     // The z-axis does nothing.
// //     //sky.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);
// //
// //     // The following determines the sun's intensity according to current time of day.
// //     // You'll notice I have hardcoded a bunch of values here. They were just the values
// //     // I felt worked best. This can obviously be made to be user configurable.
// //     // Also with some more clever code you can have different lengths for the day and
// //     // night as well.
// //
// //     // The sun is full intensity during the day.
// //     float intensityMultiplier = 1f;
// //     // Set intensity to 0 during the night night.
// //     if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f) {
// //         intensityMultiplier = 0.8f;
// //     }
// //     // Fade in the sun when it rises.
// //     else if (currentTimeOfDay <= 0.25f) {
// //         // 0.02 is the amount of time between sunrise and the time we start fading out
// //         // the intensity (0.25 - 0.23). By dividing 1 by that value we we get get 50.
// //         // This tells us that we have to fade in the intensity 50 times faster than the
// //         // time is passing to be able to go from 0 to 1 intensity in the same amount of
// //         // time as the currentTimeOfDay variable goes from 0.23 to 0.25. That way we get
// //         // a perfect fade.
// //         intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
// //     }
// //     // And fade it out when it sets.
// //     else if (currentTimeOfDay >= 0.73f) {
// //         intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
// //     }
// //
// //     // Multiply the intensity of the sun according to the time of day.
// //     float exposure = sunInitialIntensity * intensityMultiplier;
// //     RenderSettings.skybox.SetFloat("_Exposure", exposure);
// // }
  // public void sleep()
  // {
  //   daysPassed += 1;
  //   Debug.Log("Days Passed: " + daysPassed);
  //   //Application.LoadLevel("Prototype");
  // }
}
