using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: Menu 
/// </summary>
public class MenuNavigation : MonoBehaviour {
	#region Fields

	public Menu mainMenu;

	#endregion

	#region Menu headers

	public void MenuButtonNew() {
		mainMenu.currentState = MenuState.MenuNew;
	}

	public void MenuButtonHelp() {
		mainMenu.currentState = MenuState.MenuHelp;
	}
	
	public void MenuButtonCredits() {
		mainMenu.currentState = MenuState.MenuCredits;
	}

	public void MenuButtonQuit() {
		mainMenu.currentState = MenuState.MenuQuit;
	}

	#endregion

	public void PlayClick() {
		GetComponent<AudioSource>().Play();
	}

	public void LoadScene(string scene) {
		SceneManager.LoadScene(scene);
	}

	public void LoadSceneByIndex(int index) {
		SceneManager.LoadScene(index);
	}

	public void ExitApplication() {
		Application.Quit();
	}
}