using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changescene1 : MonoBehaviour {
	public void changeToScene (int changeTheScene){
		changescene.i += 1;
		Debug.Log ("i = " + changescene.i);
		SceneManager.LoadScene (changeTheScene);
	}			
}
