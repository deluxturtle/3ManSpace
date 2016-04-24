using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.net
/// 
/// Description: SwipeJoystick 
/// </summary>
public class SwipeJoystick : TouchZone {
	#region Fields

	public Image joystick;
	public Vector2 joystickVelocity;

	#endregion

	protected override void OnEnable() {
		base.OnEnable();
	}

	protected override void Start() {
		base.Start();
	}

	protected override void Update() {
		base.Update();

		if (SwipeHandler.s.CurrentSwipes > 0) {
			//print("hi");
			foreach (Swipe swipe in SwipeHandler.s.swipes) {
				if (swipe.startingZone == this) {
					if (swipe.phase != TouchPhase.Ended) {

						if (swipe.Velocity2D.magnitude <= maxRadius) {
							joystick.rectTransform.anchoredPosition = swipe.Velocity2D;
						} else {
							joystick.rectTransform.anchoredPosition = swipe.Velocity2D.normalized * maxRadius;
						}
						joystickVelocity = joystick.rectTransform.anchoredPosition - Vector2.zero;
					} else {
						Reset();
					}
				}
			}
		} else {
			Reset();
		}
	}

	protected void Reset() {
		joystick.rectTransform.anchoredPosition = Vector2.zero;
		joystickVelocity = Vector2.zero;
	}
}