using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changescene : MonoBehaviour {

	// Use this for initialization
	public static Text source;
	public static Text destination;
	public static string sourceID;
	public static string destinationID;
	public static int i = -1;
	
	public void changeToScene (int changeTheScene){
		SceneManager.LoadScene (changeTheScene);
	}	
}
