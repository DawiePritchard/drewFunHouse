using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeController : MonoBehaviour {

	private Animator anim;
	public bool fPressed = false;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey("w"))
		{
			anim.SetInteger("moving", 2);
		}
		if(Input.GetKeyUp("w"))
		{
			anim.SetInteger("moving", 0);
		}

		if(Input.GetKey("s"))
		{
			anim.SetInteger("moving", 1);
		}
		if(Input.GetKeyUp("s"))
		{
			anim.SetInteger("moving", 0);
		}

		if(Input.GetKey("a"))
		{
			anim.SetInteger("moving", 3);
		}

		if(Input.GetKeyUp("a"))
		{
			anim.SetInteger("moving", 0);
		}

		if(Input.GetKey("d"))
		{
			anim.SetInteger("moving", 4);
		}

		if(Input.GetKeyUp("d"))
		{
			anim.SetInteger("moving", 0);
		}

		if(Input.GetKey("f"))
		{
			anim.SetInteger("fight", 1);
			fPressed = true;
		}
		if(Input.GetKeyUp("f"))
		{
			anim.SetInteger("fight", 0);
			fPressed = false;
		}
		if(Input.GetMouseButtonDown(0))
		{
			anim.SetInteger("fight", 2);
		}
		if(Input.GetMouseButtonDown(1))
		{
			anim.SetInteger("fight", 3);
		}
		if(Input.GetMouseButtonUp(1))
		{
			anim.SetInteger("fight", 1);
		}
		if(Input.GetKey("r"))
		{
			anim.SetInteger("fight", 4);
		}
		if(Input.GetKeyUp("r"))
		{
			anim.SetInteger("fight", 1);
		}
		if(Input.GetKey("t"))
		{
			anim.SetInteger("fight", 5);
		}
		if(Input.GetKeyUp("t"))
		{
			anim.SetInteger("fight", 1);
		}

	}
}
