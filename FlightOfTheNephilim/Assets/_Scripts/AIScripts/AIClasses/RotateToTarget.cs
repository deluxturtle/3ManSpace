using UnityEngine;
using System.Collections;

public class RotateToTarget : MonoBehaviour {

    GameObject player;
    float rotationSpeed = 5f;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        Rotate();
	}

    void Rotate()
    {
        Vector3 dir = player.transform.position - transform.position;
        //SpecialCases for Atan2?
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
    }
}
