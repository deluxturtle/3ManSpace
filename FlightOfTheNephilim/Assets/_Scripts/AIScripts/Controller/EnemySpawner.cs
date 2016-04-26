using UnityEngine;
using System.Collections;

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 21, 2016
/// Last Modified By: Michael Dobson
/// This is the script that will control the spawning of new enemies on the screen.
/// </summary>
public class EnemySpawner : MonoBehaviour {

    public GameObject EnemyPrefab;

    GameObject TankEnemy;
    GameObject KamikazeEnemy;
    GameObject SoldierEnemy;
    float spawnDelay = 4f;
    float spawnRadius = 25f;

    GameObject player;

	// Use this for initialization
	void Start () {

        //Debug.Log(EnemyClassType.Kamikaze.GetHashCode());

        GameObject tempResource =  Instantiate( Resources.Load("Prefabs/Enemy")) as GameObject;
        
        EnemyPrefab = tempResource;
        Destroy(tempResource);

        TankEnemy = EnemyPrefab;
        KamikazeEnemy = EnemyPrefab;
        SoldierEnemy = EnemyPrefab;

        TankEnemy.AddComponent<ClassTank>();
        KamikazeEnemy.AddComponent<ClassKamikaze>();
        SoldierEnemy.AddComponent<ClassSoldier>();

        int enemyStyle = Random.Range(0, 2);
        switch(enemyStyle)
        {
            case 0:
                TankEnemy.AddComponent<AIMimic>();
                KamikazeEnemy.AddComponent<AIMimic>();
                SoldierEnemy.AddComponent<AIMimic>();
                break;
            case 1:
                TankEnemy.AddComponent<AIChaotic>();
                KamikazeEnemy.AddComponent<AIChaotic>();
                SoldierEnemy.AddComponent<AIChaotic>();
                break;
            case 2:
                TankEnemy.AddComponent<AIImmortal>();
                KamikazeEnemy.AddComponent<AIImmortal>();
                SoldierEnemy.AddComponent<AIImmortal>();
                break;
        }

        StartCoroutine(SpawnEnemy(spawnDelay, SoldierEnemy));
        player = GameObject.FindGameObjectWithTag("Player");
	}

    public IEnumerator SpawnEnemy(float SpawnDelay, GameObject mySpawner)
    {    
        while(enabled)
        {
            yield return new WaitForSeconds(SpawnDelay);
            Vector2 tempV2 = new Vector2(player.transform.position.x, player.transform.position.y);
            Instantiate(mySpawner, (Random.insideUnitCircle * spawnRadius) + tempV2, Quaternion.identity);
        }
    }
}
