using UnityEngine;
using System.Collections;

public class RotateToTarget : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, -1 * (player.transform.position - transform.position));
	}
}
