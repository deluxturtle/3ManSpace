﻿using UnityEngine;
using System.Collections;

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 7, 2016
/// This is the controller for Enemy AI behavior.
/// </summary>
public class ScriptAI : ScriptEnemy {

    /// <summary>
    /// Constructor that calls the base constructor with no params
    /// </summary>
    public ScriptAI () : base ()
    {

    }

    /// <summary>
    /// Constructor that calls the base constructor with params
    /// </summary>
    /// <param name="Health"></param>
    /// <param name="Speed"></param>
    /// <param name="Damage"></param>
    /// <param name="ShotTimer"></param>
    public ScriptAI(float Health, float Speed, float Damage, float ShotTimer)
        : base(Health, Speed, Damage, ShotTimer)
    {

    }
	
	// Update is called a specific amount of times each second
	void FixedUpdate () {
	
	}

    void Movement()
    {

    }
}
