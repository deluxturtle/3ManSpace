using UnityEngine;
using System.Collections;

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 23, 2016
/// Last Modified by: Michael Dobson
/// This is the base script for the enemy structure. 
/// This script will initialize the base values for any enemy class type
/// </summary>
public class ScriptEnemyBase : MonoBehaviour {

    //Enemy variables
    public float health; //The health of this enemy
    public Sprite mySprite; //The sprite that is rendered for this enemy
    public float damage; //The dame that this enemy does if it collides with the player

    //Enemy Protected values
    protected bool indestructable = false;
    protected GameObject player;
    protected GameObject controller;
    
    /// <summary>
    /// Base constructor for the ScriptEnemyBase Class
    /// </summary>
    public ScriptEnemyBase()
    {
        health = 1;
        mySprite = null;
        damage = 1;
        player = null;
        controller = null;
    }

    /// <summary>
    /// Setup for the ScriptEnemyBase Class
    /// </summary>
    public void SetupBase()
    {
        FindPlayer();
        FindController();
    }

    /// <summary>
    /// Apply damage to this enemy
    /// </summary>
    /// <param name="Amount">The amount of damage that will be applied to the enemy</param>
    public void TakeDamage(float Amount)
    {
        health -= Amount;
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

    void FindPlayer()
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

    void FindController()
    {
        try
        {
            controller = GameObject.Find("AIController");
        }
        catch
        {
            Debug.LogError("There must be an AIController Object in the scene");
        }
    }
}