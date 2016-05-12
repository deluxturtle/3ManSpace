using UnityEngine;
using System.Collections;

public class PU_TripleShot : MonoBehaviour {

    [Tooltip("How long the triple shot lasts.")]
    public float duration = 10f;

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Player>().EnableTripleShot(duration);
            Destroy(gameObject);
        }
    }
}
