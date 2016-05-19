using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Andrew Seba
/// Description: Health Power Up.
/// </summary>
public class PU_Health : MonoBehaviour {

    [Tooltip("Amount of ")]
    public int healthBonus = 15;

    SoundManager soundManager;
    AudioSource audioSrc;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        if(audioSrc == null)
        {
            audioSrc = gameObject.AddComponent<AudioSource>();
        }
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            audioSrc.clip = soundManager.powerUpPickup;
            audioSrc.Play();
            other.GetComponent<Player>().health += healthBonus;
            Destroy(gameObject, audioSrc.clip.length);
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
