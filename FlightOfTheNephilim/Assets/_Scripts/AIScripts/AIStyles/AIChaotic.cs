using UnityEngine;
using System.Collections;

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 14, 2016
/// Last Modified by: Michael Dobson
/// This is the specific behavior for Chaotic style enemies
/// Chaotic enemies will behave in a bullet hell style shooter
/// while trying to attack the player.
/// </summary>
public class AIChaotic : ScriptAI {

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
        Debug.Log("Override Shooting");
        GameObject tempObj = plasma;
        ScriptEnvironment tempEnvirn = tempObj.GetComponent<ScriptEnvironment>();
        tempEnvirn.SetDirection((player.transform.position + Vector3.right - transform.position).normalized);

        GameObject tempObj2 = plasma;
        ScriptEnvironment tempEnvirn2 = tempObj2.GetComponent<ScriptEnvironment>();
        tempEnvirn2.SetDirection((player.transform.position + Vector3.left - transform.position).normalized);

        Instantiate(tempObj2, transform.position, Quaternion.identity);
        Instantiate(tempObj, transform.position, Quaternion.identity);
        base.Shoot();
    }

}
