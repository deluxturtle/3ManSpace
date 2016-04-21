using UnityEngine;
using System.Collections;

public class ScriptCameraZoom : MonoBehaviour {


    public float zoomSpeed = 2f;
    Player player;
    Camera myCamera;
    float fieldOfView;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(player == null)
        {
            Debug.Log("Couldn't find player script. Please check the hirearchy of the camera.");
        }
        myCamera = GetComponent<Camera>();
        if(myCamera == null)
        {
            Debug.Log("Camera script couldn't be found check what object this script is attached too.");
            Debug.Log("This script should be attached to the camera object.");
        }
        fieldOfView = myCamera.fieldOfView;


    }

    // Update is called once per frame
    void Update ()
    {
            float targetZoom = Mathf.Lerp(fieldOfView, fieldOfView + player.shipVelocity.magnitude, zoomSpeed) ;
            myCamera.fieldOfView = targetZoom;
    }

    
}
