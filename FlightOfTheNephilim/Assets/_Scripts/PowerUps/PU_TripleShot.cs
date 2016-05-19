using UnityEngine;
using System.Collections;

public class PU_TripleShot : MonoBehaviour {


    [Tooltip("How long the triple shot lasts.")]
    public float duration = 10f;

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


	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            audioSrc.clip = soundManager.powerUpPickup;
            audioSrc.Play();
            other.GetComponent<Player>().EnableTripleShot(duration);
            Destroy(gameObject,audioSrc.clip.length);
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
