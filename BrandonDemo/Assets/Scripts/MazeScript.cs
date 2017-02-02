//This script was written by Brandon Borders | Last edited by Brandon Borders | Modified on Feb 1, 2017
//This script controls the actions and movements of the maze; specifically rotation. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeScript : MonoBehaviour {

	//Maze rotation speed
	private float rotate_speed;

	//These variables represent the two possible win areas (Yellow Cubes).
	public GameObject win_area1;
	public GameObject win_area2;


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

	//Increase maze rotation speed by variable accel. 
	public void IncreaseMazeSpeed(float accel)
	{
		rotate_speed = rotate_speed + accel;
	}

	//Change which WinArea is active; effectively moves the WinArea to
	//the other end of the maze. 
	public void ChangeWinArea()
	{
		win_area1.gameObject.SetActive(!win_area1.gameObject.activeSelf);
		win_area2.gameObject.SetActive(!win_area2.gameObject.activeSelf);
	}

	//Stops the maze
	public void StopMaze()
	{
		rotate_speed = 0.0F;
		win_area1.gameObject.SetActive (false);
		win_area2.gameObject.SetActive (false);
	}
}