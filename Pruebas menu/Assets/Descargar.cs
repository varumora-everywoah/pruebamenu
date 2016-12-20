using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Descargar : MonoBehaviour {
	WWW www;

	public Text deb;
	// Use this for initialization
	void Start () {
		StartCoroutine ("descarga");
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (""+www.bytesDownloaded);
		
	}

	IEnumerator descarga(){
		www= new WWW ("https://storage.googleapis.com/vr-city/cloud/ios/vrcityshowreel_ios_2096_42_2.mp4");
		while (!www.isDone) {
			deb.text= ("downloaded " + (www.progress * 100).ToString () + "%...");
			yield return null;
		}

		string fullPath = Application.persistentDataPath + "/vid.mp4";
		File.WriteAllBytes (fullPath, www.bytes);
	}
}
