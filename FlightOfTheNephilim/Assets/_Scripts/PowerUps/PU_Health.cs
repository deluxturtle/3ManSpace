using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Andrew Seba
/// Description: Health Power Up.
/// </summary>
public class PU_Health : MonoBehaviour {

    public int healthBonus = 15;

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);

        }
    }
}
