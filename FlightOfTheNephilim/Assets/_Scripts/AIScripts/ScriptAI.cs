using UnityEngine;
using System.Collections;

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 7, 2016
/// This is the controller for Enemy AI behavior.
/// </summary>

public enum EnemyStyle
{
    Mimic,
    Chaotic,
    Duplicator,
    Immortal,
    Trickster
};

public class ScriptAI : ScriptEnemy {

    GameObject plasma;

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
    public ScriptAI(float Health, float Damage, float ShotTimer)
        : base(Health, Damage, ShotTimer)
    {

    }
	
    public void SetupAI()
    {
        FindController();
        FindPlayer();
        GetPlasma();

        StartCoroutine(Shooting(shotTimer));
    }

    public void GetPlasma()
    {
        try
        {
            plasma = Resources.Load("Prefabs/Plasma") as GameObject;
        }
        catch
        {
            Debug.LogError("Could not get reference to Plasma in resources /n Please check for Plasma prefab in resources foler");
        }
    }

    public IEnumerator Shooting(float time)
    {
        while(enabled)
        {
            yield return new WaitForSeconds(time);
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(plasma, transform.position, Quaternion.identity);
    }
}
