using UnityEngine;
using System.Collections;

public enum EnemyClassType
{
    Soldier,
    Tank,
    Komikaze
};


public class EnemyClass : MonoBehaviour {

    public float speed; //The speed this enemy moves

    protected GameObject player;
    protected GameObject controller;
    protected Steering steering;

    //Update is run oncec per frame
    void Update()
    {
        Movement();
    }

    public EnemyClass()
    {
        speed = 0;
    }

    void Movement()
    {
        transform.Translate((steering.getSteering(transform.position, player.transform.position, speed, 4f)) * Time.deltaTime);
    }

    public void Setup()
    {
        FindPlayer();
        FindController();
    }

    /// <summary>
    /// Used to find the player on the sceen
    /// </summary>
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
            Debug.LogError("There must be an AIController in the scene");
        }

        try
        {
           steering = controller.GetComponent<Steering>();
        }
        catch
        {
            Debug.LogError("There is no KinematicSeek script on the AIController");
        }
    }
}
