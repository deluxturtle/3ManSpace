using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.net
/// 
/// Description: TouchZoneInspector 
/// </summary>
[CustomEditor( typeof( TouchZone ) )]
public class TouchZoneInspector : Editor {

	#region Fields


	#endregion

	public void OnEnable() { }

	public override void OnInspectorGUI() {
		DrawDefaultInspector();

		TouchZone myTarget = (TouchZone) target;
		BoxCollider2D collider = myTarget.GetComponent<BoxCollider2D>();
		RectTransform transform = myTarget.GetComponent<RectTransform>();

		collider.size = new Vector2( Math.Abs( transform.rect.x ) * 2, Mathf.Abs( transform.rect.y ) * 2 );
	}

}
