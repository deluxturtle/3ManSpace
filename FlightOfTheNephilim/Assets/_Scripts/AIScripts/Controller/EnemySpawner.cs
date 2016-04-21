using UnityEngine;
using System.Collections;

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 21, 2016
/// Last Modified By: Michael Dobson
/// This is the script that will control the spawning of new enemies on the screen.
/// </summary>
public class EnemySpawner : MonoBehaviour {

    GameObject EnemyPrefab;
    float spawnDelay = 4f;

	// Use this for initialization
	void Start () {
        GameObject tempResource =  Instantiate( Resources.Load("Prefabs/Enemy")) as GameObject;
        
        EnemyPrefab = tempResource;
        Destroy(tempResource);

        EnemyPrefab.AddComponent<AIMimic>();
        EnemyPrefab.AddComponent<ClassSoldier>();
        StartCoroutine(SpawnEnemy(spawnDelay, EnemyStyle.Mimic, EnemyClassType.Soldier));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator SpawnEnemy(float SpawnDelay, EnemyStyle enemyStyle, EnemyClassType enemyClass)
    {    
        while(enabled)
        {
            yield return new WaitForSeconds(SpawnDelay);
            Instantiate(EnemyPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}
