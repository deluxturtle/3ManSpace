using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Object = System.Object;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.net
/// 
/// Description: SwipeHandler 
/// </summary>
public class SwipeHandler : MonoBehaviour {

	#region Fields

	public int maxSwipes = 2;
	public int currentSwipes;
	public List<Swipe> swipes; 

	#endregion
	
	void Start () {
	
	}
	
	void Update () {
	
		/*
			get touches
			foreach
			if phase = begin
			create swipe object {startPos, fingerId, startingZone}
			if phase = moved loop thru each swipe in the collection
			if fingerid matches touch update endpos, vel2d and endingzone 
			if phase = stationary do not update
			if phase = ended/cancelled
			update as if moved and queue for removal from list?

		*/
		
	}
}

public struct Swipe {

	Vector3 startPos;
	Vector3 endPos;

	Vector2 velocity2D;

	//used to make sure the swipe is correctly calculated and not mixed with another touch during processing
	int fingerId;

	//these are the objects that are raycast against for things like virtual joysticks
	TouchZone startingZone;
	TouchZone endingZone;

	public enum Direction {
		Left, Right, Up, Down
	}
} 

