using UnityEngine;
using System.Collections;

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 7, 2016
/// Last Modified by: Michael Dobson
/// This is the specific behavior for Chaotic style enemies
/// Chaotic enemies will behave in a bullet hell style shooter
/// while trying to attack the player.
/// </summary>
public class AIChaotic : ScriptAI {

    EnemyStyle style = EnemyStyle.Chaotic;//The enemy style for this enemy group

    /// <summary>
    /// Constructor that calls base with no params
    /// </summary>
    public AIChaotic() : base()
    {

    }

    /// <summary>
    /// Constructor that calls base with params
    /// </summary>
    /// <param name="Health"></param>
    /// <param name="Speed"></param>
    /// <param name="Damage"></param>
    /// <param name="ShotTimer"></param>
    public AIChaotic(float Health, float Damage, float ShotTimer) 
        : base(Health, Damage, ShotTimer)
    {

    }

    // Use this for initialization
    void Start()
    {
        SetupAI();
    }

}
