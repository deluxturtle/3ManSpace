using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Andrew Seba
/// Description: Handles movement for the player.
/// rotates player too.
/// </summary>
public class Player : MonoBehaviour {


    public float speed = 0.1f;
    public float maxSpeed = 5f;
    public float rotateSpeed = 0.5f;

    public GameObject shipSprite;

    private Vector3 inputDirection = Vector3.zero;
    private Vector3 velocity;
	
	// Update is called once per frame
	void Update ()
    {

        inputDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        if(inputDirection.magnitude != 0)
        {
            float angle = ((Mathf.Atan2(inputDirection.y, inputDirection.x) * Mathf.Rad2Deg) - 90);
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            shipSprite.transform.rotation = Quaternion.RotateTowards(shipSprite.transform.rotation, targetRotation, rotateSpeed);

        }

        velocity += inputDirection * speed * Time.deltaTime;

        //Mike's limiter
        if(velocity.magnitude > maxSpeed)
        {
            float tempMag = velocity.magnitude;
            tempMag -= maxSpeed;
            Vector3 newVelocity = velocity.normalized;
            newVelocity *= tempMag;
            velocity -= newVelocity;
        }

        transform.Translate(velocity * Time.deltaTime);
        //Debug.DrawRay(transform.position, velocity);


    }
}
