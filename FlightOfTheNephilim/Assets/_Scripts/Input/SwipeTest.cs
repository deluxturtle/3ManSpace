using UnityEngine;
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
	
	public SwipeJoystick movePad;
	public float speed = 0.01f;

	#endregion
	
	void Start () {
	
	}
	
	void Update () {
		transform.Translate(movePad.joystickVelocity * speed * Time.deltaTime);
	}
}
