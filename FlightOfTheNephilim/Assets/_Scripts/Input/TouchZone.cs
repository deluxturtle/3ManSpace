﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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

	RectTransform myTransform;
	Rect lastSize;


	#endregion

	protected virtual void OnEnable() {
		//print( "touchzone on enable" );
		id = Random.Range(Int32.MinValue, Int32.MaxValue);
	}

	protected virtual void Start() {
		myTransform = GetComponent<RectTransform>();
		lastSize = myTransform.rect;
		gameObject.GetComponent<BoxCollider2D>().size = new Vector2( Math.Abs( myTransform.rect.x ) * 2,
																		Mathf.Abs( myTransform.rect.y ) * 2 );
	}

	protected virtual void Update() {
		UpdateCollider();


	}


	protected virtual void UpdateCollider() {
		if ( myTransform.rect != lastSize ) {
			gameObject.GetComponent<BoxCollider2D>().size = new Vector2( Math.Abs( myTransform.rect.x ) * 2,
																		Mathf.Abs( myTransform.rect.y ) * 2 );
			lastSize = myTransform.rect;
			//print("resizing");
		}
	}
}