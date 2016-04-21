using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Andrew Seba
/// Description: Handles movement for the player.
/// rotates player too.
/// </summary>
public class Player : MonoBehaviour {


    [Header("Controller Settings")]
    [Tooltip("Impulse change rate in speed.")]
    public float speed = 0.2f;
    [Tooltip("Max Ship Speed.")]
    public float maxSpeed = 5f;
    [Tooltip("How fast the ship rotates toward target direction.")]
    public float rotateSpeed = 0.5f;

    [Header("Shooting Settings")]
    [Tooltip("Place the bullet prefab here.")]
    public GameObject bulletPrefab;
    [Tooltip("How much you have to move the joystick before it will start fireing.")]
    public float shootDeadZone = 0.19f;

    [Header("Other")]
    [Tooltip("Drag the model or sprie that we want to be rotating here.")]
    public GameObject shipSprite;

    private Vector2 inputDirection = Vector2.zero;
    private Vector2 shootingDirection = Vector2.zero;
    private Vector2 velocity;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        shootingDirection = new Vector2(Input.GetAxis("Horizontal2"), -Input.GetAxis("Vertical2"));
        
        //Shoot
        if(shootingDirection.magnitude > shootDeadZone)
        {
            //TODO implement fire rate.
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<ScriptEnvironment>().SetTargetDirection(shootingDirection.normalized);
            bullet.GetComponent<ScriptEnvironment>().SetSpeed(velocity.magnitude + 5);

        }

        //Move
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
            Vector2 newVelocity = velocity.normalized;
            newVelocity *= tempMag;
            velocity -= newVelocity;
        }

        transform.Translate(velocity * Time.deltaTime);
        //Debug.DrawRay(transform.position, velocity);

        animator.SetFloat("thrust", inputDirection.magnitude);

    }
}
