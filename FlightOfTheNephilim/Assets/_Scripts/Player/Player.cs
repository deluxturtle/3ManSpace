using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Andrew Seba
/// Description: Handles movement for the player.
/// </summary>
public class Player : MonoBehaviour {

    public float speed = 5f;
    public float rotateSpeed = 0.5f;

    public GameObject shipSprite;

    private Vector3 inputDirection = Vector3.zero;
	
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


        transform.Translate(inputDirection * speed * Time.deltaTime);
        //Debug.DrawRay(transform.position, velocity);


    }
}
