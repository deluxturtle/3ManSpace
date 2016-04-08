using UnityEngine;
using System.Collections;

public struct KinematicSteeringOutput
{
    public Vector3 velocity;
    public float rotation;
}

public class KinematicSeek : MonoBehaviour {

    public Vector3 getSteering(Vector3 Enemy, Vector3 Target, float MaxSpeed)
    {

        //create the structure for output
        KinematicSteeringOutput steering = new KinematicSteeringOutput();

        //get the direction to the target
        steering.velocity = Target - Enemy;

        //the velocity is along this direction, at full speed
        steering.velocity.Normalize();
        steering.velocity *= MaxSpeed;

        //return the steering
        steering.rotation = 0;
        return steering.velocity;
    }
}
