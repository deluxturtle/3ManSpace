using UnityEngine;
using System.Collections;

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 7, 2016
/// This is the specific behavior for trickster style enemies.
/// This enemy will create weak copies of itself when it comes
/// in contact with a player
/// </summary>
public class AITrick : ScriptAI {

    EnemyStyle style = EnemyStyle.Trickster;//The enemy style for this enemy group

    /// <summary>
    /// Constructor that calls base with no params
    /// </summary>
    public AITrick() : base()
    {

    }

    /// <summary>
    /// Constructor that calls base with params
    /// </summary>
    /// <param name="Health"></param>
    /// <param name="Speed"></param>
    /// <param name="Damage"></param>
    /// <param name="ShotTimer"></param>
    public AITrick(float Health, float Speed, float Damage, float ShotTimer) 
        : base(Health, Speed, Damage, ShotTimer)
    {

    }

    // Use this for initialization
    void Start () {
        FindPlayer();
        FindController();
        GetPlasma();

        StartCoroutine(Shooting(shotTimer));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
