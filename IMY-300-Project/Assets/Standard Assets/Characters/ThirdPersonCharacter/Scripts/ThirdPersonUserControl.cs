using System;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections.Generic;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
        public bool isShowing;
        public Canvas CellphoneUI;
        public Text cellXP;
        public Text cellMoney;
        public Text cellTime;
        public Text cellDays;

        public Canvas PauseUI;
        public bool isPShowing;

        private float health;
        private float energy;
        private int XP;
        private int money;
        private int daysPassed;

        public GameObject player;

        public Light sun;
        // public Skybox sky;

        // The number of real-world seconds in one full game day.
        // Set this to 86400 for a 24-hour realtime day.
        public float secondsInFullDay = 600;

        // The value we use to calculate the current time of day.
        // Goes from 0 (midnight) through 0.25 (sunrise), 0.5 (midday), 0.75 (sunset) to 1 (midnight).
        // We define ourself what value the sunrise sunrise should be etc., but I thought these
        // values fit well. And now much of the script are hardcoded to these values.
        [Range(0,1)]
        public float currentTimeOfDay = 0.23f;

        // A multiplier other scripts can use to speed up and slow down the passing of time.
        [HideInInspector]
        public float timeMultiplier = 1f;

        // Get the initial intensity of the sun so we remember it.
        float sunInitialIntensity;


        private void Start()
        {
            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();
            sunInitialIntensity = sun.intensity;
            hidePhone();
            hidePause();
            money = 500;
            XP = 20;
        }


        private void Update()
        {
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
            if(Input.GetKeyDown("p"))
            {
              showPhone();
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
              showPause();
            }

            if(isPShowing)
            {
              Time.timeScale = 0;
            }
            else
            {
              Time.timeScale = 1;
            }
            UpdateSun();
            money = getMoney();
            XP = getXP();

            // This makes currentTimeOfDay go from 0 to 1 in the number of seconds we've specified.
            currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

            // If currentTimeOfDay is 1 (midnight) set it to 0 again so we start a new day.
            if (currentTimeOfDay >= 1)
            {
                currentTimeOfDay = 0;
                player.SendMessage("sleep");
            }
        }


        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            // read inputs
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            bool crouch = Input.GetKey(KeyCode.C);

            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v*m_CamForward + h*m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = v*Vector3.forward + h*Vector3.right;
            }
#if !MOBILE_INPUT
			// walk speed multiplier
	        if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;
        }

        void showPhone()
        {
          // Color c = cellphone.color;
          // c.a = 1;
          // cellphone.color = c;
          // isShowing = !isShowing;
          // cellphone.setActive(isShowing);
          if(isShowing == true)
          {
            CellphoneUI.enabled = false;
            // cellphone.enabled = false;
            // cellScreen.enabled = false;
            // cellXP.enabled = false;
            // cellHeader.enabled = false;
            // cellMoney.enabled = false;
            // cellBg.enabled = false;
            // cellTime.enabled = false;
            // cellDays.enabled = false;
            isShowing = false;
          }
          else{
            float currentHour = 24 * currentTimeOfDay;
            float currentMinute = 60 * (currentHour - Mathf.Floor(currentHour));
            // int daysleft = DAYS_IN_SEMESTER - daysPassed;


            cellTime.text = currentHour.ToString("0") + ":" + currentMinute.ToString("0");
            cellMoney.text = "Money: $" + money;
            cellXP.text = "XP: " + XP;
            cellDays.text = "Days left: " + (30 - daysPassed);
            CellphoneUI.enabled = true;
            // cellphone.enabled = true;
            // cellScreen.enabled = true;
            // cellXP.enabled = true;
            // cellBg.enabled = true;
            // cellHeader.enabled = true;
            // cellMoney.enabled = true;
            // cellTime.enabled = true;
            // cellDays.enabled = true;
            isShowing = true;
          }
        }

        void hidePhone()
        {
          // isShowing = !isShowing;
          // cellphone.setActive(isShowing);
          CellphoneUI.enabled = false;
          // cellphone.enabled = false;
          // cellScreen.enabled = false;
          // cellXP.enabled = false;
          // cellMoney.enabled = false;
          // cellHeader.enabled = false;
          // cellBg.enabled = false;
          // cellTime.enabled = false;
          // cellDays.enabled = false;
          isShowing = false;
        }

        void showPause()
        {
          if(isPShowing == true)
          {
            PauseUI.enabled = false;
            isPShowing = false;
          }
          else{
            PauseUI.enabled = true;
            isPShowing = true;
          }
        }

        void hidePause()
        {
          PauseUI.enabled = false;
          isPShowing = false;
        }

    void UpdateSun() {
        // Rotate the sun 360 degrees around the x-axis according to the current time of day.
        // We subtract 90 degrees from this to make the sun rise at 0.25 instead of 0.
        // I just found that easier to work with.
        // The y-axis determines where on the horizon the sun will rise and set.
        // The z-axis does nothing.
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        // The following determines the sun's intensity according to current time of day.
        // You'll notice I have hardcoded a bunch of values here. They were just the values
        // I felt worked best. This can obviously be made to be user configurable.
        // Also with some more clever code you can have different lengths for the day and
        // night as well.

        // The sun is full intensity during the day.
        float intensityMultiplier = 1;
        // Set intensity to 0 during the night night.
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f) {
          intensityMultiplier = 0;
        }
        // Fade in the sun when it rises.
        else if (currentTimeOfDay <= 0.25f) {
            // 0.02 is the amount of time between sunrise and the time we start fading out
            // the intensity (0.25 - 0.23). By dividing 1 by that value we we get get 50.
            // This tells us that we have to fade in the intensity 50 times faster than the
            // time is passing to be able to go from 0 to 1 intensity in the same amount of
            // time as the currentTimeOfDay variable goes from 0.23 to 0.25. That way we get
            // a perfect fade.
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }
        // And fade it out when it sets.
        else if (currentTimeOfDay >= 0.73f) {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }

        // Multiply the intensity of the sun according to the time of day.
        sun.intensity = sunInitialIntensity * intensityMultiplier;
        float exposure = sunInitialIntensity * intensityMultiplier;
        RenderSettings.skybox.SetFloat("_Exposure", exposure);
        //Debug.Log("Time: " + currentTimeOfDay);
    }
    // void UpdateSky() {
    //     // Rotate the sun 360 degrees around the x-axis according to the current time of day.
    //     // We subtract 90 degrees from this to make the sun rise at 0.25 instead of 0.
    //     // I just found that easier to work with.
    //     // The y-axis determines where on the horizon the sun will rise and set.
    //     // The z-axis does nothing.
    //     //sky.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);
    //
    //     // The following determines the sun's intensity according to current time of day.
    //     // You'll notice I have hardcoded a bunch of values here. They were just the values
    //     // I felt worked best. This can obviously be made to be user configurable.
    //     // Also with some more clever code you can have different lengths for the day and
    //     // night as well.0
    //
    //     // The sun is full intensity during the day.
    //     float intensityMultiplier = 1f;
    //     // Set intensity to 0 during the night night.
    //     if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f) {
    //         intensityMultiplier = 0.8f;
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
    //     float exposure = sunInitialIntensity * intensityMultiplier;
    //     RenderSettings.skybox.SetFloat("_Exposure", exposure);
    // }
    public void sleep()
    {
      daysPassed += 1;
      Debug.Log("Days Passed: " + daysPassed);
      //Application.LoadLevel("Prototype");
    }

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
}}
