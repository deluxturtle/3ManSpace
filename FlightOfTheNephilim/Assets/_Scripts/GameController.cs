using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public int score;
	public int lives;

	GameObject playerObj;

	void Awake() {
		DontDestroyOnLoad(this);
		if (instance == null) {
			instance = this;
			score = 0;
		} else {
			Destroy(gameObject);
		}
	}

	public void Respawn(GameObject player) {
		playerObj = player;
		playerObj.GetComponent<Player>().enabled = false;

		if (lives > 0) {
			Invoke("SpawnPlayer", 3);
		} else {
			SceneManager.LoadScene("GameOver");
		}
	}

	void SpawnPlayer() {
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy")) {
			Destroy(go);
		}

		playerObj.GetComponent<Player>().enabled = true;
		playerObj.GetComponent<Player>().health = 100;
		playerObj.GetComponent<Player>().UpdateHealth();
		playerObj.GetComponent<Player>().mySprite.enabled = true;
	}
}