using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoxScript : MonoBehaviour
{
	public bool isDamaging;
	public float damage = 10;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	private void OnTriggerStay(Collider col)
	{
		if(col.tag == "Player")
		{
			//Debug.Log("Collision detected");
			col.SendMessage((isDamaging)? "takeDamage":"heal", Time.deltaTime * damage);
			col.SendMessage("takeHit");
		}
	}
}
