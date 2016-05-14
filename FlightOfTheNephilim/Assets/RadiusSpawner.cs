using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.net
/// 
/// Description: RadiusSpawner 
/// </summary>
public class RadiusSpawner : MonoBehaviour {
	#region Fields

	public float spawnRate = 2;
	public float spawnRadius = 5;
	public GameObject toSpawn;
	public int poolSize = 50;

	List<GameObject> pool;

	#endregion

	void Start() {
		//toSpawn = Resources.Load<GameObject>("Prefabs/Enemy");
		if (toSpawn) {
			pool = new List<GameObject>();
			InvokeRepeating("SpawnEnemy", spawnRate, spawnRate);
		}
	}

	void SpawnEnemy() {
		Vector2 spawnPos = new Vector2(transform.position.x, transform.position.y);

		if (pool.Count < poolSize) {
			GameObject temp = Instantiate(toSpawn, (Random.insideUnitCircle * spawnRadius) + spawnPos, Quaternion.identity) as GameObject;
			pool.Add(temp);
		} else {
			GameObject temp = pool[0];
			pool.Remove(temp);
			temp.transform.position = (Random.insideUnitCircle * spawnRadius) + spawnPos;
			pool.Add(temp);
		}
	}
}