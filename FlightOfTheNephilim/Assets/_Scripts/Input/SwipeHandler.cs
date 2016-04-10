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

	

	#endregion
	
	void Start () {
	
	}
	
	void Update () {
	
	}
}

public struct Swipe {

	Vector3 startPos;
	Vector3 endPos;

	Vector2 velocity2D;
	
	//these are the objects that are raycast against for things like virtual joysticks
	TouchZone startingZone;
	TouchZone endingZone;

	public enum Direction {
		Left, Right, Up, Down
	}
} 

