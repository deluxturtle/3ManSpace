using UnityEngine;
using System.Collections;

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 21, 2016
/// Last Modified by: Michael Dobson
/// This is the basic constructor for an enemy,
/// this constcructor will be overriden by subsequent scripts
/// to create the different AI types for this game.
/// </summary>
public class ScriptEnemy : MonoBehaviour {

    //Enemy Variables
    [Tooltip("The amount of health that this enemy has")]
    public float health; //Health of this enemy
    //[Tooltip("The damage this enemy does on successful attack hit")]
    //public float shotDamage; //Damage of this enemy on successful attack
    //[Tooltip("The frequency the enemy will shoot")]
    //public float shotTimer; //How often the enemy will shoot
    [Tooltip("The sprite that repesents this enemy")]
    public Sprite mySprite; //The sprite that represents this enemy
    [Tooltip("The amount of damage caused if we collide with the player")]
    public float damage; //How much damage this enemy does if we collide with the enemy

    public bool indestructable = false;

    //Enemy References
    protected GameObject player; //reference of the player for the enemy
    protected GameObject controller; //reference to the AI controller object

    /// <summary>
    /// Base constructor with no params
    /// </summary>
    public ScriptEnemy()
    {
        health = 1;
        //shotDamage = 0;
        //shotTimer = 0;
        player = null;
    }

    /// <summary>
    /// Base Constructor with Param
    /// </summary>
    /// <param name="Health"></param>
    /// <param name="Speed"></param>
    /// <param name="ShotDamage"></param>
    /// <param name="ShotTimer"></param>
    public ScriptEnemy(float Health)
    {
        health = Health;
        //shotDamage = ShotDamage;
        //shotTimer = ShotTimer;
        player = null;
    }

    /// <summary>
    /// Apply damage to this enemy
    /// </summary>
    /// <param name="amount">amount of damage to be applied</param>
    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Destruction();
        }
    }

    /// <summary>
    /// Destruction of this object
    /// </summary>
    public virtual void Destruction()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!indestructable)
        {
            if(other.tag == "PBullet")
            {
                TakeDamage(other.GetComponent<ScriptEnvironment>().damage);
            }
        }
    }

    /// <summary>
    /// Used to find the player on the sceen
    /// </summary>
    public void FindPlayer()
    {
        try
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        catch
        {
            Debug.LogError("There is no player in the scene");
        }
    }

    public void FindController()
    {
        try
        {
            controller = GameObject.Find("AIController");
        }
        catch
        {
            Debug.LogError("There must be an AIController in the scene");
        }
    }
}
