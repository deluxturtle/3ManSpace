using UnityEngine;
using System.Collections;

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 19, 2016
/// Last Modified by: Michael Dobson
/// This is the specific behavior for Chaotic style enemies
/// Chaotic enemies will behave in a bullet hell style shooter
/// while trying to attack the player.
/// </summary>
public class AIChaotic : ScriptAI {

    float spreadAngle = 10f;

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
        myStyle = EnemyStyle.Chaotic;
        SetupAI();
    }

    public override void Shoot()
    {
        //Debug.Log("Override Shooting");

        GameObject tempObj = plasma;
        ScriptEnvironment tempEnvirn = tempObj.GetComponent<ScriptEnvironment>();

        GameObject tempObj2 = plasma;
        ScriptEnvironment tempEnvirn2 = tempObj2.GetComponent<ScriptEnvironment>();

        Instantiate(tempObj, transform.position, Quaternion.Euler(0, 0, spreadAngle));
        Instantiate(tempObj2, transform.position, Quaternion.Euler(0, 0, -spreadAngle));
        base.Shoot();
    }

}
