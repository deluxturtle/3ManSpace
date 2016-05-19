using UnityEngine;
using System.Collections;

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 19, 2016
/// Last Modified by: Michael Dobson
/// This is the specific behavior for Immortal style enemies.
/// Immortal enemies will respawn after being "destroyed".
/// Upon dropping below 0 health the enemy will go inactive for a 
/// set amount of time before resuming activitys with (full?) health again
/// </summary>
public class AIImmortal : AIMimic {

    float respawnTimer = 4; //The time that this enemy will take to respawn upon destruction
    int returnHealth = 5; //The amount of health that the enemy will return to active with
    bool canShoot = true; //Determines if we are currently able to shoot

    ClassKamikaze classKamikaze; //Reference to the Kamikaze class script for this enemy
    ClassSoldier classSoldier; //Reference to the Soldier class script for this enemy
    ClassTank classTank; //Reference to the Tank class script for this enemy
    RotateToTarget rotateScript; //reference to the rotation script for this enemy

    /// <summary>
    /// Constructor that calls base with no params
    /// </summary>
    public AIImmortal() : base()
    {

    }

    /// <summary>
    /// Constructor that calls base with params
    /// </summary>
    /// <param name="Health"></param>
    /// <param name="Speed"></param>
    /// <param name="Damage"></param>
    /// <param name="ShotTimer"></param>
    public AIImmortal(float Health, float Damage, float ShotTimer) 
        : base(Health, Damage, ShotTimer)
    {

    }

    // Use this for initialization
    void Start () {
        myStyle = EnemyStyle.Immortal;
        SetupAI();
        switch(myClass)
        {
            case EnemyClassType.Kamikaze:
                try
                {
                    classKamikaze = GetComponent<ClassKamikaze>();
                }
                catch
                {
                    Debug.LogError("We are class Kamikaze but there is no ClassKamikaze on object");
                }
                break;
            case EnemyClassType.Soldier:
                try
                {
                    classSoldier = GetComponent<ClassSoldier>();
                }
                catch
                {
                    Debug.LogError("We are class Soldier but there is no ClassKamikaze on object");
                }
                break;
            case EnemyClassType.Tank:
                try
                {
                    classTank = GetComponent<ClassTank>();
                }
                catch
                {
                    Debug.LogError("We are class Tank but there is no ClassKamikaze on object");
                }
                break;
            case EnemyClassType.Undefined:
                Debug.LogError("This enemy is undefined as class type. Ensure all enemies have a class type");
                break;
        }
        try
        {
            rotateScript = GetComponentInChildren<RotateToTarget>();
        }
        catch
        {
            Debug.LogError("Can not get reference to RotateToTarget Script on child object");
        }
    }

    public override void Destruction()
    {
        StartCoroutine(Reconstruct());
    }

    public override void Shoot()
    {
        if(canShoot)
            base.Shoot();
    }

    IEnumerator Reconstruct()
    {
        Debug.LogWarning("Conducting Repairs");
        rotateScript.enabled = false;
        switch(myClass)
        {
            case EnemyClassType.Kamikaze:
                classKamikaze.enabled = false;
                break;
            case EnemyClassType.Soldier:
                classSoldier.enabled = false;
                break;
            case EnemyClassType.Tank:
                classTank.enabled = false;
                break;
        }
        canShoot = false;
        yield return new WaitForSeconds(respawnTimer);
        canShoot = true;
        rotateScript.enabled = true;
        switch (myClass)
        {
            case EnemyClassType.Kamikaze:
                classKamikaze.enabled = true;
                break;
            case EnemyClassType.Soldier:
                classSoldier.enabled = true;
                break;
            case EnemyClassType.Tank:
                classTank.enabled = true;
                break;
        }
        health = returnHealth;
    }
}
