using UnityEngine;
using System.Collections;

public class ClassKamikaze : EnemyClass {

    EnemyClassType enemyClass = EnemyClassType.Komikaze;

    public ClassKamikaze() : base ()
    {

    }

    // Use this for initialization
    void Start () {
        Setup();
	}
}
