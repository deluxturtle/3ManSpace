using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Andrew Seba
/// Description: Controls the time scale of the game.
/// </summary>
public class PauseController : MonoBehaviour {


    public void _Pause()
    {
        Time.timeScale = 0;
    }

    public void _UnPause()
    {
        Time.timeScale = 1;
    }
	
}
