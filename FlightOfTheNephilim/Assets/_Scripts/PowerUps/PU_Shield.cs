using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Andrew Seba
/// </summary>
public class PU_Shield : MonoBehaviour {
    
    /// <summary>
    /// On collision destroy this object and create a shield bubble around the player.
    /// </summary>
    /// <param name="other"></param>
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject shield = Instantiate(other.GetComponent<Player>().shieldPrefab) as GameObject;
            shield.transform.parent = other.transform;
            shield.transform.localPosition = new Vector3(0, 0.25f, 0);
            Destroy(gameObject);
        }
    }
}
