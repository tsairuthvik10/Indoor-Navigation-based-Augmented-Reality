using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Outputobject : MonoBehaviour {

	public static string destinationID;

	[SerializeField]
	private InputField input;

	void Awake(){
		//input = GameObject.Find ();
	}	

	public void GetInput(string destination){
		destinationID = destination;
		//Debug.Log ("Entered : " + destinationID); 
	}
}
