using UnityEngine;
using System.Collections;

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 7, 2016
/// This is the specific behavior for duplicator style enemies
/// Duplicator enemies will split into multiple copies of itself
/// when it's health drops to 0. The copies will be less powerful
/// and have less health.
/// </summary>
public class AIDuplicator : AIMimic {

    EnemyStyle style = EnemyStyle.Duplicator;//The enemy style for this enemy group

    /// <summary>
    /// Constructor that calls base with no params
    /// </summary>
    public AIDuplicator() : base()
    {

    }

    /// <summary>
    /// Constructor that calls base with params
    /// </summary>
    /// <param name="Health"></param>
    /// <param name="Speed"></param>
    /// <param name="Damage"></param>
    /// <param name="ShotTimer"></param>
    public AIDuplicator(float Health, float Speed, float Damage, float ShotTimer) 
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
}
