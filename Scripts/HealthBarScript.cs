using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
	public Image HealthImg;
	public Text HealthText;

	private float health = 150;
	private float MAX_HEALTH = 150;
	// Use this for initialization
	void Start ()
	{
		updateHealthBar();

	}

	// Update is called once per frame
	void Update ()
	{
		updateHealthBar();
		//Debug.Log("Health Updated");
	}

	private void updateHealthBar()
	{
		float ratio = health/MAX_HEALTH;
		HealthImg.rectTransform.localScale = new Vector3(ratio, 1, 1);
		HealthText.text = "Health: " + (ratio*100).ToString("0") + "%";
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


}
