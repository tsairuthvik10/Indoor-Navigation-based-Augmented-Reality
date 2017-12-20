using UnityEngine;
using System.Collections;
using System.Threading;
using UnityEngine.SceneManagement;


public class NFCExample : MonoBehaviour
{
	public GUIText nfc_output_text;
	static public string valu;
	static public string prevval="";
	int count= 0;
	AndroidJavaClass pluginTutorialActivityJavaClass;
	void Start ()
	{
		
		AndroidJNI.AttachCurrentThread ();
		pluginTutorialActivityJavaClass = new AndroidJavaClass ("com.twinsprite.nfcplugin.NFCPluginTest");
		nfc_output_text.text = "Scan nfc tag\n";
	}

	void Update ()
	{
		string value = pluginTutorialActivityJavaClass.CallStatic<string> ("getValue");
		valu = value;
		if (value==prevval) nfc_output_text.text = "Scan nfc tag\n";
		if (Outputobject.destinationID == value && value!=prevval){
			nfc_output_text.text = value;
			prevval = value;
			Application.LoadLevel(2);
		}
		else if (value !="" && value!=prevval){
			if (count < 50) nfc_output_text.text = value + " detected\n Loading directions";
			if (count==50) nfc_output_text.text = value + " detected\n Loading directions .";
			if (count==100) nfc_output_text.text = value + " detected\n Loading directions ..";
			if (count==100) nfc_output_text.text = value + " detected\n Loading directions ....";
			count++;
			if (count> 200) {
				prevval = value;
				Application.LoadLevel(2);
			}
			
		}
		else {
				
			}
	//	changescene.sourceID = value;

		
	}
	
}