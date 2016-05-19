using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Andrew Seba
/// </summary>
public class PU_Shield : MonoBehaviour {

    SoundManager soundManager;
    AudioSource audioSrc;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        if (audioSrc == null)
        {
            audioSrc = gameObject.AddComponent<AudioSource>();
        }
    }

    /// <summary>
    /// On collision destroy this object and create a shield bubble around the player.
    /// </summary>
    /// <param name="other"></param>
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            audioSrc.clip = soundManager.powerUpPickup;
            audioSrc.Play();
            GameObject shield = Instantiate(other.GetComponent<Player>().shieldPrefab) as GameObject;
            shield.transform.parent = other.transform;
            shield.transform.localPosition = new Vector3(0, 0.25f, 0);
            Destroy(gameObject,audioSrc.clip.length);
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
