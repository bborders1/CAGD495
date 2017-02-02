//This script was written by Brandon | Last edited by Brandon | Modified on Jan 28, 2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColideScript : MonoBehaviour {

    public PointsScript Points;
    //The amount of points subtracted for colliding with the maze
    public int Maze_Penalty = 5;
    //The amount of points awarded for colliding with the win area
    public int Win_Reward = 100;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Enter key sets point value to 1000 to aid testing development. 
		if(Input.GetKey(KeyCode.Return))
        {
            Points.SetPoints(1000);
        }
	}

    //OnTriggerEnter requires a Collider. When the player collides with a collider, change the point value accordingly.
    //If that collider is a maze, subtract points. If that collider is the WinArea, add points.  
    //CURRENT ISSUE: Collision does not work
    //(This issue has been left in as an example to show how I comment issues within the code)
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Maze")
        {
            Points.SubtractPoints(Maze_Penalty);
        }
        if (col.gameObject.name == "WinArea")
        {
            Points.AddPoints(Win_Reward);
        }
    }
}
