using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.net
/// 
/// Description: Scorable 
/// </summary>
public class Scorable : MonoBehaviour {

	#region Fields

	public int scoreValue;

	#endregion
	
	void Start () {
		if (scoreValue == 0) {
			scoreValue = Random.Range(1, 100);
		}
	}
	
	void OnDestroy () {
		GameController.instance.score += scoreValue;
	}
}
