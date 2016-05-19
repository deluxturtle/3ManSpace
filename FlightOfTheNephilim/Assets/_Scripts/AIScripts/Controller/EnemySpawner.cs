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

    public GameObject TankEnemy;
    public GameObject KamikazeEnemy;
    public GameObject SoldierEnemy;
    float spawnDelay = 4f;
    float spawnRadius = 25f;

    int enemyStyle;

    GameObject player;

	// Use this for initialization
	void Start () {

        //Debug.Log(EnemyClassType.Kamikaze.GetHashCode());

        //GameObject tempResource =  Instantiate( Resources.Load("Prefabs/Enemy")) as GameObject;
        
        //EnemyPrefab = tempResource;
        //Destroy(tempResource);

        Debug.LogWarning("Enemy Prefab: " + EnemyPrefab);

        //TankEnemy = EnemyPrefab;
        //KamikazeEnemy = EnemyPrefab;
        //SoldierEnemy = EnemyPrefab;
       
        Debug.LogWarning("Soldier Prefab: " + SoldierEnemy);
        enemyStyle = Random.Range(0, 2);
        //TankEnemy.AddComponent<ClassTank>();
        //KamikazeEnemy.AddComponent<ClassKamikaze>();
        //SoldierEnemy.AddComponent<ClassSoldier>();

        //int enemyStyle = Random.Range(0, 2);
        //switch (enemyStyle)
        //{
        //    case 0:
        //        TankEnemy.AddComponent<AIMimic>();
        //        KamikazeEnemy.AddComponent<AIMimic>();
        //        SoldierEnemy.AddComponent<AIMimic>();
        //        break;
        //    case 1:
        //        TankEnemy.AddComponent<AIChaotic>();
        //        KamikazeEnemy.AddComponent<AIChaotic>();
        //        SoldierEnemy.AddComponent<AIChaotic>();
        //        break;
        //    case 2:
        //        TankEnemy.AddComponent<AIImmortal>();
        //        KamikazeEnemy.AddComponent<AIImmortal>();
        //        SoldierEnemy.AddComponent<AIImmortal>();
        //        break;
        //}
        Debug.LogWarning("Pre Coroutine Soldier: " + SoldierEnemy);
        StartCoroutine(SpawnEnemy(spawnDelay, SoldierEnemy));
        //Vector2 tempV2 = new Vector2(player.transform.position.x, player.transform.position.y);
        //Instantiate(SoldierEnemy, (Random.insideUnitCircle * spawnRadius) + tempV2, Quaternion.identity);
        player = GameObject.FindGameObjectWithTag("Player");
	}

    public IEnumerator SpawnEnemy(float SpawnDelay, GameObject mySpawner)
    {
        Debug.LogWarning("Post coroutine: " + mySpawner);
        while(enabled)
        {
            yield return new WaitForSeconds(SpawnDelay);
            Vector2 tempV2 = new Vector2(player.transform.position.x, player.transform.position.y);
            Debug.LogWarning(mySpawner);
            GameObject tempObj = Instantiate(mySpawner, (Random.insideUnitCircle * spawnRadius) + tempV2, Quaternion.identity) as GameObject;
            tempObj.AddComponent<ClassSoldier>();
            switch (enemyStyle)
            {
                case 0:
                    //TankEnemy.AddComponent<AIMimic>();
                    //KamikazeEnemy.AddComponent<AIMimic>();
                    tempObj.AddComponent<AIMimic>();
                    break;
                case 1:
                    //TankEnemy.AddComponent<AIChaotic>();
                    //KamikazeEnemy.AddComponent<AIChaotic>();
                    tempObj.AddComponent<AIChaotic>();
                    break;
                case 2:
                    //TankEnemy.AddComponent<AIImmortal>();
                    //KamikazeEnemy.AddComponent<AIImmortal>();
                    tempObj.AddComponent<AIImmortal>();
                    break;
            }
        }
    }

    //public void InvokeEnemy(GameObject spawnEnemy)
    //{
    //    Debug.LogWarning(spawnEnemy);
    //    Vector2 tempV2 = new Vector2(player.transform.position.x, player.transform.position.y);
    //    GameObject.Instantiate(spawnEnemy, (Random.insideUnitCircle * spawnRadius) + tempV2, Quaternion.identity);
    //}
}
