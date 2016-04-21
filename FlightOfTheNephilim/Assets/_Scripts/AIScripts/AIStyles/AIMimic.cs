using UnityEngine;
using System.Collections;

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 12, 2016
/// Last Modified by: Michael Dobson
/// This is the specific behavior for Mimic style enemies
/// Mimic enemies will be a simple style enemy that just attacks
/// in a standard behavior.
/// </summary>
public class AIMimic : ScriptAI {

    /// <summary>
    /// Constructor that calls base with no params
    /// </summary>
    public AIMimic () : base()
    {

    }

    /// <summary>
    /// Constructor that calls base with params
    /// </summary>
    /// <param name="Health"></param>
    /// <param name="Speed"></param>
    /// <param name="Damage"></param>
    /// <param name="ShotTimer"></param>
    public AIMimic (float Health, float Damage, float ShotTimer) 
        : base(Health, Damage, ShotTimer)
    {

    }

	// Use this for initialization
	void Start () {
        myStyle = EnemyStyle.Mimic;
        SetupAI();
    }
}
