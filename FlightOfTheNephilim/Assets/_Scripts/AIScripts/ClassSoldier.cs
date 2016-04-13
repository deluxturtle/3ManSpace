using UnityEngine;
using System.Collections;

public class ClassSoldier : EnemyClass {

    EnemyClassType enemyClass = EnemyClassType.Soldier;

    public ClassSoldier() : base ()
    {

    }

    // Use this for initialization
    void Start () {
        Setup();
	}
}
