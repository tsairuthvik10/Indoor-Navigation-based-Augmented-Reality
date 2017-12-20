using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endscene : MonoBehaviour {

	// Use this for initialization

		public void changeToScene (int changeTheScene){
		SceneManager.LoadScene (changeTheScene);
	}
	
	public void ClickExit (){
		Application.Quit();
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
