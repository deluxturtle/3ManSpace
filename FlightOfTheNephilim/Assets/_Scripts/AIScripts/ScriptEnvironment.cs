using UnityEngine;
using System.Collections;

/// <summary>
/// @author Michael Dobson
/// This script will be the AI that environmental enemies
/// will use to perform actions in the game.
/// </summary>
public class ScriptEnvironment : ScriptEnemy {

    Vector3 travelDirection;

    public ScriptEnvironment(float Health, float Speed, float Damage, float ShotTimer) 
        : base (Health, Speed, Damage, ShotTimer)
    {
        
    }

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        travelDirection = (player.transform.position - transform.position).normalized;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    /// <summary>
    /// Environmental object move function
    /// </summary>
    void Move()
    {
        transform.Translate(travelDirection * speed * Time.deltaTime);
    }
}
