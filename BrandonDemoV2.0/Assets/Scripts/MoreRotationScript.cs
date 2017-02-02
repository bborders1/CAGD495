//This script was written by Brandon Borders | Last edited by Brandon Borders | Modified on Feb 1, 2017
//This script causes the two mid barriers to rotate when a certain point value is reached. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreRotationScript : MonoBehaviour {

	private float rotate_speed;

	// Use this for initialization
	void Start () 
	{
		rotate_speed = 0F;
	}

	// FixedUpdate is called once per frame
	void FixedUpdate ()
	{
		transform.Rotate (0, rotate_speed, 0);
	}

	//Begin rotating the middle walls
	public void StartRotation()
	{
		rotate_speed = -1.0F;
	}
		
}
