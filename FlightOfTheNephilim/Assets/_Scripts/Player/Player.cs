using UnityEngine;
using UnityEngine.UI;
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
	[Tooltip("What angle the 2 other bullets shoot at.")]
	public float tripleShotAngle = 20f;

	[Header("GUI")]
	public GameObject tripleTimerGUI;
	public Slider healthBar;

	[Header("Other")]
	public GameObject shieldPrefab;
	[Tooltip("Drag the model or sprie that we want to be rotating here.")]
	public GameObject shipSprite;
	[Tooltip("The joystick used for Moving")]
	public SwipeJoystick moveStick;
	[Tooltip("The joystick used for Shooting")]
	public SwipeJoystick shootStick;

	//Hidden
	[HideInInspector]
	public Vector2 shipVelocity;

	Vector2 inputDirection = Vector2.zero;
	Vector2 shootingDirection = Vector2.zero;
	bool canShoot = true;
	Animator animator;
	bool tripleShot = false; //Powerup toggle.
	float tripleTimer;
	Text tripleTimerText;

	public SpriteRenderer mySprite;
	bool isDead = false;
    SoundManager soundManager;

	void Start() {
		tripleTimerText = tripleTimerGUI.GetComponentInChildren<Text>();
		healthBar.maxValue = health;
		healthBar.value = health;
		animator = GetComponent<Animator>();
        soundManager = FindObjectOfType<SoundManager>();

		if (!moveStick || !shootStick) {
			moveStick = GameObject.Find("Move Stick").GetComponent<SwipeJoystick>();
			shootStick = GameObject.Find("Shoot Stick").GetComponent<SwipeJoystick>();
		}
	}

	// Update is called once per frame
	void Update() {
		inputDirection = moveStick.joystickVelocity;
		shootingDirection = shootStick.joystickVelocity;

		Shoot();

		//Move
		if (inputDirection.magnitude != 0) {
			float angle = ((Mathf.Atan2(inputDirection.y, inputDirection.x) * Mathf.Rad2Deg) - 90);
			Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
			shipSprite.transform.rotation = Quaternion.RotateTowards(shipSprite.transform.rotation, targetRotation, rotateSpeed);
		}

		shipVelocity += inputDirection * speed * Time.deltaTime;

		//Mike's limiter
		if (shipVelocity.magnitude > maxSpeed) {
			float tempMag = shipVelocity.magnitude;
			tempMag -= maxSpeed;
			Vector2 newVelocity = shipVelocity.normalized;
			newVelocity *= tempMag;
			shipVelocity -= newVelocity;
		}

		transform.Translate(shipVelocity * Time.deltaTime);

		//Debug.DrawRay(transform.position, velocity);

		animator.SetFloat("thrust", inputDirection.magnitude);

		UpdateHealth();
	}

	public void UpdateHealth() {
		healthBar.value = health;
		if (health <= 0) {
			isDead = true;
		}

		if (isDead) {
			isDead = false;
			print("Ran lives decrement " + GameController.instance.lives);
			GameController.instance.lives--;
			GameController.instance.Respawn(gameObject);
			mySprite.enabled = false;
		}
	}

	/// <summary>
	/// Handles the bullet instantiation.
	/// </summary>
	void Shoot() {
		//Shoot
		if (shootingDirection.magnitude > shootDeadZone) {
			if (canShoot) {
				//TODO implement fire rate.
				GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
				bullet.GetComponent<ScriptEnvironment>().SetTargetDirection(shootingDirection.normalized);
				bullet.GetComponent<ScriptEnvironment>().speed = (shipVelocity.magnitude + bulletSpeed);

				if (tripleShot) {
					GameObject bulletLeft = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
					GameObject bulletRight = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;

					bulletLeft.GetComponent<ScriptEnvironment>()
					          .SetTargetDirection(Quaternion.Euler(0, 0, tripleShotAngle) * (Vector3) shootingDirection.normalized +
					                              (Vector3) inputDirection.normalized);
					bulletLeft.GetComponent<ScriptEnvironment>().speed = (shipVelocity.magnitude + bulletSpeed);
					bulletRight.GetComponent<ScriptEnvironment>()
					           .SetTargetDirection(Quaternion.Euler(0, 0, -tripleShotAngle) * (Vector3) shootingDirection.normalized +
					                               (Vector3) inputDirection.normalized);
					bulletRight.GetComponent<ScriptEnvironment>().speed = (shipVelocity.magnitude + bulletSpeed);
                    //soundManager.GetComponent<AudioSource>().clip 
				}
                else
                {
                    soundManager.GetComponent<AudioSource>().clip = soundManager.playerShoot;
                }

                soundManager.GetComponent<AudioSource>().Play();

                //bullet.GetComponentInChildren<SpriteRenderer>().transform.rotation = Quaternion.Euler(0, 0, );
                canShoot = false;


				Invoke("EnableShot", shootRate);
			}
		}
	}

	/// <summary>
	/// Enables triple shot and starts tripleshot timer.
	/// </summary>
	public void EnableTripleShot(float duration) {
		tripleTimer = duration;
		tripleShot = true;
		tripleTimerGUI.SetActive(true);
		InvokeRepeating("TripleCountDown", 0, 1);
	}

	/// <summary>
	/// Sets the gui text to current time left.
	/// </summary>
	void TripleCountDown() {
		tripleTimer--;
		tripleTimerText.text = tripleTimer.ToString();
		if (tripleTimer <= 0) {
			tripleShot = false;
			tripleTimerGUI.SetActive(false);
			CancelInvoke("TripleCountDown");
		}
	}

	void EnableShot() {
		canShoot = true;
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "EBullet" && enabled) {
			health -= (int) other.GetComponent<ScriptEnvironment>().damage;
			UpdateHealth();
			Destroy(other.gameObject);
		}
	}
}