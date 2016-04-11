using UnityEngine;
using System.Collections;

public enum EnemyStyle
{
    Mimic,
    Chaotic,
    Duplicator,
    Immortal,
    Trickster
};

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 10, 2016
/// Last Modified by: Michael Dobson
/// This is the controller for Enemy AI behavior.
/// </summary>
public class ScriptAI : ScriptEnemy {

    GameObject plasma;

    //Public variables
    [Tooltip("The radius that this enemy will shoot at the player")]
    public float shootingRadius; //The radius around the player that the enemy will fire at the player
    [Tooltip("The radius that this enemy will stop seeking the player")]
    public float radiusOfSatisfaction; //The radius that th will stop seeking the target Should be less than shooting radius

    protected EnemyController enemyControllerScript; //The controller that stores the data for all enemies

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
        GetControllerScript();

        StartCoroutine(Shooting(shotTimer));
    }

    void GetPlasma()
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

    void GetControllerScript()
    {
        try
        {
            enemyControllerScript = controller.GetComponent<EnemyController>();
        }
        catch
        {
            Debug.LogError("Could not get reference to EnemyController Script on AIController. /n Please Check to make sure there is an EnemyController Script on the AIController");
        }
    }

    IEnumerator Shooting(float time)
    {
        while(enabled)
        {
            yield return new WaitForSeconds(time);
            Vector3 tempVector;
            tempVector = player.transform.position - transform.position; 
            if(tempVector.magnitude < shootingRadius)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(plasma, transform.position, Quaternion.identity);
    }
}
