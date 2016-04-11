using UnityEngine;
using System.Collections;

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 10, 2016
/// Last Modified by: Michael Dobson
/// This is the specific behaviors for the Soldier class.
/// This class will try to get near the player and shoot them.
/// This class will also relentlessly pursue the player
/// </summary>
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
