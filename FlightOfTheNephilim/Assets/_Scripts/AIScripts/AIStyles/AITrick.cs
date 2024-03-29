﻿using UnityEngine;
using System.Collections;

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 12, 2016
/// Last Modified by: Michael Dobson
/// This is the specific behavior for trickster style enemies.
/// This enemy will create weak copies of itself when it comes
/// in contact with a player
/// </summary>
public class AITrick : ScriptAI {

    /// <summary>
    /// Constructor that calls base with no params
    /// </summary>
    public AITrick() : base()
    {

    }

    /// <summary>
    /// Constructor that calls base with params
    /// </summary>
    /// <param name="Health"></param>
    /// <param name="Speed"></param>
    /// <param name="Damage"></param>
    /// <param name="ShotTimer"></param>
    public AITrick(float Health, float Damage, float ShotTimer) 
        : base(Health, Damage, ShotTimer)
    {

    }

    // Use this for initialization
    void Start () {
        myStyle = EnemyStyle.Trickster;
        SetupAI();
    }

}
