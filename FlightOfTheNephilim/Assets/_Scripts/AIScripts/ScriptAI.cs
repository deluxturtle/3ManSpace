using UnityEngine;
using System.Collections;

public enum EnemyStyle
{
    Undefined,
    Mimic,
    Chaotic,
    Duplicator,
    Immortal,
    Trickster
};

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 14, 2016
/// Last Modified by: Michael Dobson
/// This is the controller for Enemy AI behavior.
/// </summary>
public class ScriptAI : ScriptEnemy {


    //Public variables
    [Tooltip("The radius that this enemy will shoot at the player")]
    public float shootingRadius; //The radius around the player that the enemy will fire at the player
    [Tooltip("The damage this enemy does on successful attack hit")]
    public float shotDamage; //Damage of this enemy on successful attack
    [Tooltip("The frequency the enemy will shoot")]
    public float shotTimer; //How often the enemy will shoot
    [Tooltip("The speed that the bullets fired from this enemy will travel")]
    public float shotSpeed;
    [Tooltip("The speed that the enemy will rotate towards the player")]
    float rotationSpeed = 100f;
    //[Tooltip("The radius that this enemy will stop seeking the player")]
    //public float radiusOfSatisfaction; //The radius that this enemy will stop seeking the target Should be less than shooting radius

    //References
    protected GameObject plasma;
    protected EnemyStyle myStyle; //This is the style of this specific enemy
    protected EnemyClassType myClass; //This is the class of this specific enemy
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
        : base(Health)
    {
        shotDamage = Damage;
        shotTimer = ShotTimer;
    }
	
    /// <summary>
    /// Update is run once per frame
    /// </summary>
    void Update()
    {
        
    }

    protected void SetupAI()
    {
        FindController();
        FindPlayer();
        GetControllerScript();
        GetData();
        GetPlasma();

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

        try
        {
            ScriptEnvironment tempEnvironment = plasma.GetComponent<ScriptEnvironment>();
            tempEnvironment.speed = shotSpeed;
            tempEnvironment.damage = shotDamage;
        }
        catch
        {
            Debug.LogError("Could not find the ScriptEnvironment on Plasma prefab. Ensure there is a ScriptEnvironment on Plasma prefab.");
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

    void GetData()
    {
        EnemyData? myData = null;

        if (gameObject.GetComponent<ClassKamikaze>() != null)
        {
            myClass = EnemyClassType.Kamikaze;
        }
        else if (gameObject.GetComponent<ClassSoldier>() != null)
        {
            myClass = EnemyClassType.Soldier;
        }
        else if (gameObject.GetComponent<ClassTank>() != null)
        {
            myClass = EnemyClassType.Tank;
        }
        else
        {
            Debug.LogError("There is no Class type on this enemy. There must be a Class and a Style for an enemy to function");
        }

        if(myClass != EnemyClassType.Undefined)
        {
            myData = enemyControllerScript.GetEnemyData(myStyle, myClass);
        }
        else
        {
            Debug.LogError("Enemy has no defined Class Type. Ensure there is a class type on the enemy.");
        }

        if(myData != null)
        {
            health = myData.Value.Health;
            shotDamage = myData.Value.ShotDamage;
            damage = myData.Value.ShipDamage;
            mySprite = myData.Value.mySprite;
            shootingRadius = myData.Value.ShotRadius;
            shotTimer = myData.Value.GetShotTimer();
            shotSpeed = myData.Value.ShotSpeed;
            SpriteRenderer myRenderer = GetComponentInChildren<SpriteRenderer>();
            myRenderer.sprite = myData.Value.mySprite;
        }
        else
        {
            Debug.LogError("There was no Style Class combination available from the controller." +
                            " Check the style class type " + myStyle.ToString() + myClass.ToString() 
                            +" for data.");
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

    public virtual void Shoot()
    {
        Debug.Log("Base Shooting");
        Instantiate(plasma, transform.position, Quaternion.identity);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, shootingRadius);
    }
}
