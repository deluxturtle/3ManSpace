using UnityEngine;
using System.Collections;

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 10, 2016
/// Last Modified by: Michael Dobson
/// This is the specific behaviors for the Tank class.
/// This class will try to shoot the enemy from a distance with 
/// powerful attacks. This class is not very manuverable.
/// </summary>
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
