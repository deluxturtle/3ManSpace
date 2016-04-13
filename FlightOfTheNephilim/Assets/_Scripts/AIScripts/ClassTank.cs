using UnityEngine;
using System.Collections;

public class ClassTank : EnemyClass {

    EnemyClassType enemyClass = EnemyClassType.Tank;

    public ClassTank() : base ()
    {

    }

	// Use this for initialization
	void Start () {
        Setup();
	}
}
