using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Andrew Seba
/// Description: Handles movement for the player.
/// rotates player too.
/// </summary>
public class Player : MonoBehaviour {


    [Header("Player Settings")]
    public int health = 100;
    [Tooltip("Impulse change rate in speed.")]
    public float speed = 0.2f;
    [Tooltip("Max Ship Speed.")]
    public float maxSpeed = 5f;
    [Tooltip("How fast the ship rotates toward target direction.")]
    public float rotateSpeed = 0.5f;

    [Header("Shooting Settings")]
    [Tooltip("Place the bullet prefab here.")]
    public GameObject bulletPrefab;
    [Tooltip("Time between shots.")]
    public float shootRate = 0.5f;
    [Tooltip("How fast the bullet will move.")]
    public float bulletSpeed = 6;
    [Tooltip("How much damage the bullet will do.")]
    public float bulletDamage = 10f;
    [Tooltip("How much you have to move the joystick before it will start fireing.")]
    public float shootDeadZone = 0.19f;

    [Header("Other")]
    [Tooltip("Drag the model or sprie that we want to be rotating here.")]
    public GameObject shipSprite;

    //Hidden
    [HideInInspector]
    public Vector2 shipVelocity;


    private Vector2 inputDirection = Vector2.zero;
    private Vector2 shootingDirection = Vector2.zero;
    private bool canShoot = true;
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
            if (canShoot)
            {
                //TODO implement fire rate.
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
                bullet.GetComponent<ScriptEnvironment>().SetTargetDirection(shootingDirection.normalized);
                bullet.GetComponent<ScriptEnvironment>().SetSpeed(shipVelocity.magnitude + bulletSpeed);
                //bullet.GetComponent<ScriptEnvironment>().sp
                canShoot = false;
                Invoke("EnableShot", shootRate);
            }

        }

        //Move
        if(inputDirection.magnitude != 0)
        {
            float angle = ((Mathf.Atan2(inputDirection.y, inputDirection.x) * Mathf.Rad2Deg) - 90);
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            shipSprite.transform.rotation = Quaternion.RotateTowards(shipSprite.transform.rotation, targetRotation, rotateSpeed);

        }

        shipVelocity += inputDirection * speed * Time.deltaTime;

        //Mike's limiter
        if(shipVelocity.magnitude > maxSpeed)
        {
            float tempMag = shipVelocity.magnitude;
            tempMag -= maxSpeed;
            Vector2 newVelocity = shipVelocity.normalized;
            newVelocity *= tempMag;
            shipVelocity -= newVelocity;
        }

        transform.Translate(shipVelocity * Time.deltaTime);
        //Debug.DrawRay(transform.position, velocity);

        animator.SetFloat("thrust", inputDirection.magnitude);

    }

    void EnableShot()
    {
        canShoot = true;
    }
}
