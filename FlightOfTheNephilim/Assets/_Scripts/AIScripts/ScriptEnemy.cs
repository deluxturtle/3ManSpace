﻿using UnityEngine;
using System.Collections;

/// <summary>
/// @author Michael Dobson
/// This is the basic constructor for an enemy,
/// this constcructor will be overriden by subsequent scripts
/// to create the different AI types for this game.
/// </summary>
public class ScriptEnemy : MonoBehaviour {

    //Enemy Variables
    [Tooltip("The amount of health that this enemy has")]
    public float health; //Health of this enemy
    [Tooltip("The speed that this enemy will move")]
    public float speed; //Speed of this enemy
    [Tooltip("The damage this enemy does on successful attack hit")]
    public float damage; //Damage of this enemy
    [Tooltip("The frequency the enemy will shoot")]
    public float shotTimer; //How often the enemy will shoot

    //Enemy References
    protected GameObject player; //reference of the player for the enemy

    public ScriptEnemy(float Health, float Speed, float Damage, float ShotTimer)
    {
        health = Health;
        speed = Speed;
        damage = Damage;
        shotTimer = ShotTimer;
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

    public void Destruction()
    {
        Destroy(gameObject);
    }
}