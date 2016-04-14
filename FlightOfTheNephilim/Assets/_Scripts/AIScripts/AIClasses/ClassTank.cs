using UnityEngine;
using System.Collections;

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 12, 2016
/// Last Modified by: Michael Dobson
/// This is the specific behaviors for the Tank class.
/// This class will try to shoot the enemy from a distance with 
/// powerful attacks. This class is not very manuverable.
/// </summary>
public class ClassTank : EnemyClass {

    public ClassTank() : base ()
    {

    }

	// Use this for initialization
	void Start () {
        myClass = EnemyClassType.Tank;
        Setup();
	}
}
