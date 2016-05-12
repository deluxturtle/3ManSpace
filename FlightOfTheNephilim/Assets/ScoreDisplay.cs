using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.net
/// 
/// Description: ScoreDisplay 
/// </summary>
public class ScoreDisplay : MonoBehaviour {

	#region Fields

	Text thisText;

	#endregion

	void Start() {
		thisText = GetComponent<Text>();
	}

	void Update () {
		if (GameController.instance) {
			thisText.text = "Score: " + GameController.instance.score;
		}
	}
}
