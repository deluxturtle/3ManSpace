using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.net
/// 
/// Description: PowerUpSpawner 
/// </summary>
public class PowerUpSpawner : MonoBehaviour {

	#region Fields

	public int spawnChance = 10;

	public GameObject[] powerUps;

	#endregion

	void OnDestroy() {
		if (Random.Range(1, 100) <= spawnChance) {
			int temp = Random.Range(0, powerUps.Length);
			Instantiate(powerUps[temp], transform.position, Quaternion.identity);
		}
	}
}
