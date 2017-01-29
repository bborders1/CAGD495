//This script was written by Brandon | Last edited by Brandon | Modified on Jan 28, 2017

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsScript : MonoBehaviour {

    //Player's points.
    [Tooltip("Points value anything 0 or greater")]
    public int points;
    public Text Point_Text;

	// Use this for initialization
	void Start ()
    {
        points = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    //Function AddPoints requires an int named num that describes what amount to
    //increase the points by.
    public void AddPoints(int num)
    {
        points = points + num;
        UpdateText();
    }

    //Function SubtractPoints requires an int named num that describes what amount to
    //decrease the points by.
    public void SubtractPoints(int num)
    {
        points = points - num;
        //Set points to 0 if they are below 0. 
        if (points < 0)
            SetPoints(0);
        UpdateText();
    }

    //Function SetPoints requires an int named num that describes what amount to change
    //the point to.
    public void SetPoints(int num)
    {
        points = num;
        UpdateText();
    }

    //Updates the Points Textbox to display the current point value
    void UpdateText()
    {
        //Sanitize points
        if (points < 0)
            Debug.LogError("Points value is less than zero.");
        Point_Text.text = points.ToString();
    }
}
