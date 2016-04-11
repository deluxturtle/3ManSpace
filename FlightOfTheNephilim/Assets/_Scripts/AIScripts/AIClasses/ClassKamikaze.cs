using UnityEngine;
using System.Collections;

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 10, 2016
/// Last Modified by: Michael Dobson
/// This is the specific behaviors for the Kamikaze class.
/// This class will try to ram the player to cause maximum damage.
/// </summary>
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
