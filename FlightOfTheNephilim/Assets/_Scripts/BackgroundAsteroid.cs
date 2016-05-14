using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.net
/// 
/// Description: BackgroundAsteroid 
/// </summary>
public class BackgroundAsteroid : MonoBehaviour {
	#region Fields

	public GameObject objectToTrack;
	public float radius;
	public Sprite[] sprites;

	#endregion

	void Start() {
		GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];

		if (!objectToTrack) {
			objectToTrack = GameObject.Find("Ship");
		}
	}

	void Update() {
		if ((transform.position - objectToTrack.transform.position).magnitude > radius) {
			if (objectToTrack) {
				Vector2 spawnPos = new Vector2(objectToTrack.transform.position.x, objectToTrack.transform.position.y);
				transform.position = (Random.insideUnitCircle * radius) + spawnPos;
			}
		}
	}
}