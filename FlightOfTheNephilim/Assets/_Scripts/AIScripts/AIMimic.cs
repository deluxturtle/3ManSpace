using UnityEngine;
using System.Collections;

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 7, 2016
/// This is the specific behavior for Mimic style enemies
/// Mimic enemies will be a simple style enemy that just attacks
/// in a standard behavior.
/// </summary>
public class AIMimic : ScriptAI {

    EnemyStyle style = EnemyStyle.Mimic;//The enemy style for this enemy group

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
    public AIMimic (float Health, float Speed, float Damage, float ShotTimer) 
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
