using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioClip playerShoot;
    public AudioClip powerUpPickup;

    [HideInInspector]
    public AudioSource audioSrc;

    void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
    }
}
