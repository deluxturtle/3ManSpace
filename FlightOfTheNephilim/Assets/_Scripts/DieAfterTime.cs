using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.net
/// 
/// Description: DieAfterTime 
/// </summary>
public class DieAfterTime : MonoBehaviour {

	#region Fields

	public float time = 3.5f;

	#endregion
	
	void Start () {
		Invoke("Die", time);
	}
	
	void Die () {
		Destroy(gameObject);
	}
}
