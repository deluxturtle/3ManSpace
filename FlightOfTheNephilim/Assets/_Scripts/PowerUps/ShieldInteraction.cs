using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Andrew Seba
/// Description:Shield destroys self after 10 seconds
/// </summary>
public class ShieldInteraction : MonoBehaviour {

    public float shieldDuration = 10f;
    //Seconds before shield duration will end to tell the user it will be going away soon.
    public float warningTime = 3f;
    //Time between toggling blinks.
    public float blinkRate = 0.05f;

    //Private
    bool blink = false;
    SpriteRenderer graphic;
    

    void Start()
    {
        graphic = GetComponent<SpriteRenderer>();
        Destroy(gameObject, shieldDuration);
        StartCoroutine("BlinkStarter");
    }

    /// <summary>
    /// If the other object is an enemy bullet it will destroy it.
    /// </summary>
    /// <param name="other">Other object in collision</param>
	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "EBullet")
            Destroy(other.gameObject);
    }

    /// <summary>
    /// Controls when the blinking starts.
    /// </summary>
    /// <returns>null</returns>
    IEnumerator BlinkStarter()
    {
        float timeLeft = shieldDuration;
        while (true)
        {
            timeLeft -= Time.deltaTime;
            //Debug.Log(timeLeft);
            //Debug.Log(blink);
            if(timeLeft <= warningTime)
            {
                StartCoroutine("Blink");
                break;
            }
            yield return null;
        }
    }

    /// <summary>
    /// Toggles the blinking at the blink rate.
    /// </summary>
    /// <returns>null</returns>
    IEnumerator Blink()
    {
        while (true)
        {
            if (!blink)
            {
                graphic.color = Color.clear;
            }
            else
            {
                graphic.color = Color.white;
            }

            blink = !blink;

            yield return new WaitForSeconds(blinkRate);
        }
    }
}
