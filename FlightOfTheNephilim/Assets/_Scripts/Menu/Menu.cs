using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: TouchMenuHandler 
/// </summary>
public class Menu : MonoBehaviour {
	#region Fields

	public GameObject[] menus;

	public bool rememberMenuOnClose;
	public MenuState currentState;
	MenuState prevState;

	public int comfort;
	Vector2 previous;
	Vector2 current;
	float touchDelta;

	#endregion

	void Start() {
		foreach (GameObject menu in menus) {
			menu.SetActive(false);
		}

		prevState = currentState;
		menus[(int) currentState].SetActive(true);
	}

	void Update() {
		if (Input.touchCount == 1) {
			if (Input.GetTouch(0).phase == TouchPhase.Began) {
				previous = Input.GetTouch(0).position;
			} else if (Input.GetTouch(0).phase == TouchPhase.Ended) {
				current = Input.GetTouch(0).position;
				touchDelta = current.magnitude - previous.magnitude;

				if (Mathf.Abs(touchDelta) > comfort) {
					//print("swipe read with delta of " + touchDelta);
					if (touchDelta > 0) {
						//print("left and bottom");
						if (Mathf.Abs(current.x - previous.x) > Mathf.Abs(current.y - previous.y)) {
							//print("left");
						} else {
							currentState = GetNextState();
							//print("bottom");
						}
					} else {
						//print("top and right");
						if (Mathf.Abs(current.x - previous.x) > Mathf.Abs(current.y - previous.y)) {
							//print("right");
						} else {
							currentState = GetPreviousState();
							//print("top");
						}
					}
				}
			}
		}

		if (prevState != currentState) {
			menus[(int) currentState].SetActive(true);
			menus[(int) prevState].SetActive(false);
			prevState = currentState;
		}
	}

	public void SetState(MenuState state) {
		currentState = state;
	}

	MenuState GetNextState() {
		if ((int) currentState >= Enum.GetValues(typeof (MenuState)).Length - 1) {
			//on final state
			return currentState;
		} else {
			return currentState + 1;
		}
	}

	MenuState GetPreviousState() {
		if ((int) currentState <= 0) {
			//on first state
			return currentState;
		} else {
			return currentState - 1;
		}
	}

}

public enum MenuState {
	MenuNew,
	MenuHelp,
	MenuCredits,
	MenuQuit
}