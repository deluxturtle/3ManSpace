using UnityEngine;
using System.Collections;

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 12, 2016
/// Last Modified by: Michael Dobson
/// This is the specific behavior for duplicator style enemies
/// Duplicator enemies will split into multiple copies of itself
/// when it's health drops to 0. The copies will be less powerful
/// and have less health.
/// </summary>
public class AIDuplicator : AIMimic {

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
    public AIDuplicator(float Health, float Damage, float ShotTimer) 
        : base(Health, Damage, ShotTimer)
    {

    }

    // Use this for initialization
    void Start () {
        myStyle = EnemyStyle.Duplicator;
        SetupAI();
    }
}
