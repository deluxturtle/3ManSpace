using UnityEngine;
using System.Collections;

/// <summary>
/// @author Michael Dobson
/// This script will be the AI that environmental enemies
/// will use to perform actions in the game.
/// </summary>
public class ScriptEnvironment : ScriptEnemy {

    Vector3 travelDirection; //the direction that we are going to be traveling

    //internal use only
    float outOfPlay = 20f;

    /// <summary>
    /// Constructor that calls base contstuctor with no params
    /// </summary>
    public ScriptEnvironment() : base()
    {

    }

    /// <summary>
    /// Constructor that calls base constructor with params
    /// </summary>
    /// <param name="Health"></param>
    /// <param name="Speed"></param>
    /// <param name="Damage"></param>
    /// <param name="ShotTimer"></param>
    public ScriptEnvironment(float Health, float Speed, float Damage, float ShotTimer) 
        : base (Health, Speed, Damage, ShotTimer)
    {
        
    }

	// Use this for initialization
	void Start () {
        FindPlayer();
        travelDirection = (player.transform.position - transform.position).normalized;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        CheckPosition();
	}

    /// <summary>
    /// Environmental object move function
    /// </summary>
    void Move()
    {
        transform.Translate(travelDirection * speed * Time.deltaTime);
    }

    /// <summary>
    /// Used to clean up objects that are off the screen and do not impact gameplay any further
    /// </summary>
    void CheckPosition()
    {
        if (transform.position.x > outOfPlay || transform.position.x < -outOfPlay ||
            transform.position.y > outOfPlay || transform.position.y < -outOfPlay)
        {
            Debug.Log("Object removed for being outside of playing field");
            Destruction();
        }
    }
}
