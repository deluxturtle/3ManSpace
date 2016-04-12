﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.net
/// 
/// Description: SwipeTest 
/// </summary>
public class SwipeTest : MonoBehaviour {

	#region Fields

	public SwipeHandler handler;
	public TouchZone movePad;
	public float speed = 0.01f;

	#endregion
	
	void Start () {
	
	}
	
	void Update () {
		if (handler.CurrentSwipes > 0) {
			//print("hi");
			foreach (Swipe swipe in handler.swipes) {
				if (swipe.startingZone == movePad) {
					//print(swipe.Distance);

					transform.Translate(swipe.Velocity2D * speed * Time.deltaTime);

				}
			}
		}
	}
}
