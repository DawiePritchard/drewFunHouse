using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public Animator enemy;

	// Use this for initialization
	void Start () {
		enemy = this.GetComponent<Animator>();
		enemy.SetBool("hit", true);
		enemy.SetInteger ("action", 0);
	}

	// Update is called once per frame
	void Update () {

	}

	public void takeHit()
	{
		enemy.SetBool("hit", true);
	}
}
