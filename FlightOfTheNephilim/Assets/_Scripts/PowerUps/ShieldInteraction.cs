using UnityEngine;
using System.Collections;

public class ShieldInteraction : MonoBehaviour {

    void Start()
    {
        Debug.Log("Destroying Shield in 10 seconds.");
        Destroy(gameObject, 10f);
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bullet")
            Destroy(other.gameObject);
    }
}
