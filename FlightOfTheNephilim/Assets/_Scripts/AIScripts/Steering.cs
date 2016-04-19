using UnityEngine;
using System.Collections;

public struct KinematicSteeringOutput
{
    public Vector3 velocity;
    public float rotation;
}

/// <summary>
/// @author Michael Dobson
/// Last Modified: April 10, 2016
/// Last Modified by: Michael Dobson
/// This is the Kinematic steering script that will allow for control over the steering behaviors
/// that are sent to the AI.
/// </summary>
public class Steering : MonoBehaviour
{
    //Normal Vectors
    //Vector3 topRight = Vector3.up + Vector3.right;
    //Vector3 topLeft = Vector3.up + Vector3.left;
    //Vector3 bottomLeft = Vector3.down + Vector3.left;
    //Vector3 bottomRight = Vector3.down + Vector3.right;

    //GameObject player;

    //Run once on startup of this script
    void Start()
    {
        //player = GameObject.FindWithTag("Player");
    }

    public Vector3 getSteering(Vector3 Character, Vector3 Target, float MaxSpeed, float RadiusOfSatisfaction)
    {
        Vector3 distanceToTarget = Target - Character;
        //if we are outside the radius of satisfaction
        if(distanceToTarget.magnitude > RadiusOfSatisfaction)
        {
            //seek the target, return the seek
            return getSeek(Character, Target, MaxSpeed, RadiusOfSatisfaction, 1f);
        }

        //if we are inside the radius of satisfaction, 
        if(distanceToTarget.magnitude < RadiusOfSatisfaction)
        {
            //find the three closest corners of the player to me

            //choose a corner at random

            //seek that corner, return the seek

        }
        return Vector3.zero;
    }

    Vector3 getSeek(Vector3 Character, Vector3 Target, float MaxSpeed, float Radius, float TimeToTarget)
    {

        //create the structure for output
        KinematicSteeringOutput steering = new KinematicSteeringOutput();

        //get the direction to the target
        steering.velocity = Target - Character;

        //if we are in the radius of satisfaction do not have a steering
        if(steering.velocity.magnitude < Radius)
        {
            steering.velocity = Vector3.zero;
        }

        //if we need to still move to our target, we would like to get there in TimeToTarget
        steering.velocity /= TimeToTarget;

        //if the speed is to fast, clip it to MaxSpeed
        if(steering.velocity.magnitude > MaxSpeed)
        {
            steering.velocity.Normalize();
            steering.velocity *= MaxSpeed;
        }

        //return the steering
        steering.rotation = 0;
        return steering.velocity;
    }
}
