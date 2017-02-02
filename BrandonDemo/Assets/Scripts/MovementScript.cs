//This script was written by Brandon Borders | Last edited by Brandon Borders | Modified on Feb 1, 2017
//This script controls player movement and collision with other objects, along with the consequences due
//to said collisions. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementScript : MonoBehaviour 
{
	//Player speed
	[Tooltip("Player speed of 0 or higher.")]
	public float speed;

	//variable for how much maze rotation increases by when it increases
	private float maze_rotation_increment = 0.1F;

	//rb is a rigidbody variable which is used to get information from
	//the rigidbody component
	private Rigidbody rb;

	//Text which shows the number of points
	public Text point_text;

	//The number of points.
	[Tooltip("Points value; any amount allowed.")]
	public int points;

	//The amount of points awarded for touching the WinArea (Yellow Cube)
	private int win_points;

	//The amount of points needed to start the middle walls spinning
	private int spin_goal;

	//The amount of points needed to win
	private int victory_goal;

	public MazeScript maze;

	public MoreRotationScript gets_harder1;
	public MoreRotationScript gets_harder2;

	// Start initiates starting variables
	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		//Set Starting Variables
		win_points = 100;
		spin_goal = 1200;
		victory_goal = 2000;
		SetPointText ();
		//Sanitize Speed
		if (speed < 0) 
		{
			Debug.LogError ("Player speed is negative!");
		}
	}

	// FixedUpdate is called once per frame
	void FixedUpdate ()
	{
		float move_horizontal = Input.GetAxis ("Horizontal");
		float move_vertical = Input.GetAxis ("Vertical");
	
		//movement is the vector3 of the player's movement.
		Vector3 movement = new Vector3 (move_horizontal, 0.0f, move_vertical);

		//Each frame, move the player according to the movement variable. 
		rb.AddForce (movement * speed);
	}

	// OnTriggerEnter is called when player collides with another gameobject. 
	//Variable other is the gameobject collided with.
	void OnTriggerEnter(Collider other)
	{
		//On collision with WinArea (Yellow Cube)...
		if (other.gameObject.CompareTag ("WinPickup")) 
		{
			//Move WinArea to other position in maze
			//other.gameObject.SetActive (false);
			maze.ChangeWinArea();
			//Increase Maze Rotation Speed
			maze.IncreaseMazeSpeed(maze_rotation_increment);
			//Gain a bunch of points.
			points = points + win_points;
			//Set the points
			SetPointText ();
			//When the points reach 1200, start rotating the middle walls.
			if (points >= spin_goal) 
			{
				gets_harder1.StartRotation ();
				gets_harder2.StartRotation ();
			}
			//When the points reach the victory goal, Achieve victory. 
			if (points >= victory_goal) 
			{
				maze.StopMaze ();
				point_text.text = "Victory!!!";

			}
		}
	}

	//Sets the on-screen text to display the current point value. 
	void SetPointText()
	{
		point_text.text = "Points: " + points.ToString ();
	}

}
