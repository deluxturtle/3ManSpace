using UnityEngine;
using System.Collections;

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 7, 2016
/// This is the specific behavior for Immortal style enemies.
/// Immortal enemies will respawn after being "destroyed".
/// Upon dropping below 0 health the enemy will go inactive for a 
/// set amount of time before resuming activitys with (full?) health again
/// </summary>
public class AIImmortal : AIMimic {

    float respawnTimer; //The time that this enemy will take to respawn upon destruction

    /// <summary>
    /// Constructor that calls base with no params
    /// </summary>
    public AIImmortal() : base()
    {

    }

    /// <summary>
    /// Constructor that calls base with params
    /// </summary>
    /// <param name="Health"></param>
    /// <param name="Speed"></param>
    /// <param name="Damage"></param>
    /// <param name="ShotTimer"></param>
    public AIImmortal(float Health, float Speed, float Damage, float ShotTimer) 
        : base(Health, Speed, Damage, ShotTimer)
    {

    }

    // Use this for initialization
    void Start () {
        FindPlayer();
        FindController();
        GetPlasma();

        StartCoroutine(Shooting(shotTimer));
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Destruction()
    {
        
    }
}
