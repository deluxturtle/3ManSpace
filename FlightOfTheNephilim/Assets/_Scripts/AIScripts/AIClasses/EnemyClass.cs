using UnityEngine;
using System.Collections;

public enum EnemyClassType
{
    Undefined,
    Soldier,
    Tank,
    Kamikaze
};

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 14, 2016
/// Last Modified by: Michael Dobson
/// This is the base for the enemy class type. 
/// </summary>
public class EnemyClass : MonoBehaviour {

    [Tooltip("The speed at which the enemy will seek the players position")]
    public float speed; //The speed this enemy moves
    [Tooltip("The radius at which the enemy will stop seeking the player")]
    public float radiusOfSatisfaction; //My radius of satisfaction

    //References
    protected GameObject player; //reference to the player object
    protected GameObject controller; //reference to the ai controller
    protected Steering steering; //reference to the steering script on the ai controller
    protected EnemyController enemyControllerScript; //Enemycontroller Script on the controller object
    protected EnemyStyle myStyle; //The style of this enemy
    protected EnemyClassType myClass; //The class of this enemy

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
        transform.Translate((steering.getSteering(transform.position, player.transform.position, speed, radiusOfSatisfaction)) * Time.deltaTime);
    }

    public void Setup()
    {
        FindPlayer();
        FindController();
        Invoke("GetData", 2f);
    }

    /// <summary>
    /// Used to find the player on the scene
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

    /// <summary>
    /// Used to find the controller objecy on the scene
    /// </summary>
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

        try
        {
            enemyControllerScript = controller.GetComponent<EnemyController>();
        }
        catch
        {
            Debug.LogError("Could not get reference to Enemycontroller Script on the AIController. Please ensure there is an AIController Script on the AIController.");
        }
    }

    void GetData()
    {
        EnemyData? myData = null;

        if(gameObject.GetComponent<AIMimic>() != null)
        {
            myStyle = EnemyStyle.Mimic;
        }
        else if(gameObject.GetComponent<AIChaotic>() != null)
        {
            myStyle = EnemyStyle.Chaotic;
        }
        else if(gameObject.GetComponent<AIImmortal>() != null)
        {
            myStyle = EnemyStyle.Immortal;
        }
        else if(gameObject.GetComponent<AIDuplicator>() != null)
        {
            myStyle = EnemyStyle.Duplicator;
        }
        else if(gameObject.GetComponent<AITrick>() != null)
        {
            myStyle = EnemyStyle.Trickster;
        }
        else
        {
            Debug.LogError("There is no Style Script on the enemy. Enemies must have a style and a class in order to function");
        }

        if(myStyle != EnemyStyle.Undefined)
        {
            myData = enemyControllerScript.GetEnemyData(myStyle, myClass);
        }

        if(myData != null)
        {
            speed = myData.Value.Speed;
            radiusOfSatisfaction = myData.Value.GetRadius();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusOfSatisfaction);
        if(controller != null)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, transform.position + (steering.getSteering(transform.position, player.transform.position, speed, radiusOfSatisfaction)));
        }
    }
}
