using UnityEngine;
using System.Collections;

public class ShipTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetAxis("Horizontal") > 0)
        {
            Debug.Log("Right");
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            Debug.Log("Left");
        }

        if (Input.GetButton("Jump"))
        {
            Debug.Log("Jump");
        }
	}
}
