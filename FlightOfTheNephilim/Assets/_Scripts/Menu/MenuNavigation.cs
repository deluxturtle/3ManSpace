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

	void Start() {}

	void Update() {}

	#region Menu headers

	public void MenuButtonNew() {
		mainMenu.currentState = MenuState.MenuNew;
	}

	public void MenuButtonLoad() {
		mainMenu.currentState = MenuState.MenuLoad;
	}

	public void MenuButtonHelp() {
		mainMenu.currentState = MenuState.MenuHelp;
	}

	public void MenuButtonSettings() {
		mainMenu.currentState = MenuState.MenuSettings;
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
}