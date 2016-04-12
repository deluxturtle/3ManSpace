using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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

	public int CurrentSwipes {
		get { return swipes.Count; }
	}

	public List<Swipe> swipes;

	List<int> swipesToRemove;

	#endregion

	void Start() {
		swipes = new List<Swipe>();
		swipesToRemove = new List<int>();
	}

	void Update() {
		if (Input.touchCount > 0) {
			foreach (Touch next in Input.touches) {
				switch (next.phase) {
					case TouchPhase.Began:

						//create swipe object {startPos, fingerId, startingZone}
						Swipe temp = new Swipe(next.position, next.fingerId);

						RaycastHit2D hit = Physics2D.Raycast(next.position, Vector2.zero);
						if (hit) {
							if (hit.transform.GetComponent<TouchZone>()) {
								temp.startingZone = hit.transform.GetComponent<TouchZone>();
							}
						}
						swipes.Add(temp);

						//print("began distance: " + temp.Distance);
						break;
					case TouchPhase.Moved:

						//	loop thru each swipe in the collection
						//if fingerid matches touch update endpos, vel2d and endingzone
						foreach (Swipe swipe in swipes) {
							if (swipe.fingerId == next.fingerId) {
								//same finger
								swipe.endPos = next.position;

								//print( "moved distance: " + swipe.Distance );
							}
						}
						break;
					case TouchPhase.Stationary:

						// nadda
						break;
					case TouchPhase.Canceled:
					case TouchPhase.Ended:

						//update as if moved and queue for removal from list?
						foreach (Swipe swipe in swipes) {
							if (swipe.fingerId == next.fingerId) {
								//same finger
								swipe.endPos = next.position;

								//add id to list of swipes to remove
								swipesToRemove.Add(swipe.fingerId);

								//print( "ended distance: " + swipe.Distance );
							}
						}
						break;
					default:

						//
						break;
				}
			}
		}
	}

	void LateUpdate
		() {
		//clean up
		for (int i = 0; i < swipes.Count; i++) {
			Swipe swipe = swipes[i];
			for (int j = 0; j < swipesToRemove.Count; j++) {
				int idToRemove = swipesToRemove[j];
				if (swipe.fingerId == idToRemove) {
					swipes.Remove(swipe);
					swipesToRemove.Remove(idToRemove);
				}
			}
		}

		//print(swipes.Count);
	}
}

public class Swipe {

	public Vector3 startPos;
	public Vector3 endPos;

	public float Distance {
		get {
			if (!object.Equals(startPos, default(Vector3)) && !object.Equals(endPos, default(Vector3))) {
				return startPos.magnitude - endPos.magnitude;
			} else {
				return 0;
			}
		}
	}

	public Vector2 Velocity2D {
		get {
			if (!object.Equals(startPos, default(Vector3)) && !object.Equals(endPos, default(Vector3))) {
				return new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);
			} else {
				return Vector2.zero;
			}
		}
	}

	//used to make sure the swipe is correctly calculated and not mixed with another touch during processing
	public int fingerId;

	//these are the objects that are raycast against for things like virtual joysticks
	public TouchZone startingZone;
	public TouchZone endingZone;

	public Swipe(Vector3 startPos, int fingerId) {
		this.startPos = startPos;
		this.fingerId = fingerId;
	}

	public enum Direction {
		Left,
		Right,
		Up,
		Down
	}
}