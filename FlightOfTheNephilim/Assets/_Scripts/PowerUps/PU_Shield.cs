using UnityEngine;
using System.Collections;

public class PU_Shield : MonoBehaviour {
    

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Instantiate(other.GetComponent<Player>().shieldPrefab);
        }
    }
}
