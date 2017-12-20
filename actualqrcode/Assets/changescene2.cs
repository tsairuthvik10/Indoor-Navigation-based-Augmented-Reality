using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changescene2 : MonoBehaviour {

	public GameObject object1;
	public changescene1 cs1;

/*	public void start(){
		object1 = GameObject.FindGameObjectWithTag ("changescene1");
		cs1 = object1.GetComponent<changescene1> ();
	}*/
	public void changeToScene (int changeTheScene){
		SceneManager.LoadScene (changeTheScene);
	}	
				
}
