using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public int score;
	public int lives;

	void Awake() {
		DontDestroyOnLoad(this);
		if (instance == null) {
			instance = this;
			score = 0;
		} else {
			Destroy(gameObject);
		}
	}

	public void Respawn() {
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

		GameObject temp = Resources.Load<GameObject>("Prefabs/Player");
		Instantiate(temp, Vector3.zero, Quaternion.identity);
	}

}