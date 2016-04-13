using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.net
/// 
/// Description: StaticTest 
/// </summary>
public static class StaticTest{

	#region Fields

	public static int testInt = 0;

	public static bool TestProp {
		get { return true; }
		set {}
	}

	#endregion

	static StaticTest() {
		Debug.Log("static constructor called");
	}

	public static void Test() {
		Debug.Log("test method called");
	}
}
