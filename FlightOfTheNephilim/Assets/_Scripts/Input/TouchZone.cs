﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.net
/// 
/// Description: TouchZone functions as single touch aswell as swipe zones until seperate functionality is needed.
/// </summary>
public class TouchZone : MonoBehaviour {
	#region Fields

	public int id;
	public float maxRadius;
	public int maxTouches;

	#endregion

	void OnEnable() {
		id = Random.Range(Int32.MinValue, Int32.MaxValue);
	}

	void Start() {}

	void Update() {
		//gameObject.GetComponent<BoxCollider2D>().size = new Vector2
		gameObject.GetComponent<BoxCollider2D>().size = new Vector2( Math.Abs(gameObject.GetComponent<RectTransform>().rect.x) * 2, Mathf.Abs( gameObject.GetComponent<RectTransform>().rect.y) * 2);
	
	}

}