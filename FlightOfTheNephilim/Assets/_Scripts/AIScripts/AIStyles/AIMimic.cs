using UnityEngine;
using System.Collections;

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 7, 2016
/// Last Modified by: Michael Dobson
/// This is the specific behavior for Mimic style enemies
/// Mimic enemies will be a simple style enemy that just attacks
/// in a standard behavior.
/// </summary>
public class AIMimic : ScriptAI {

    EnemyStyle style = EnemyStyle.Mimic;//The enemy style for this enemy group
    EnemyClass myClass;//The class that this enemy is

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
        SetupAI();
        GetData();

    }

    void GetData()
    {
        try
        {
            ClassKamikaze kamikaze;
            ClassSoldier soldier;
            ClassTank tank;
            
        }
        catch
        {
            Debug.LogError("There is no Class type on this enemy. There must be a Class and a Style for an enemy to function");
        }
    }

}
