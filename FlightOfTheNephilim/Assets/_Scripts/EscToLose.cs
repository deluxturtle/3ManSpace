using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.net
/// 
/// Description: EscToLose 
/// </summary>
public class EscToLose : MonoBehaviour {

	#region Fields

	#endregion
	
	void Start () {
	
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			SceneManager.LoadScene("GameOver");
		}
	}
}
