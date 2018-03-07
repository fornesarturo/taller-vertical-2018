using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaseFileController : MonoBehaviour {

	public Transform canvas;
	public Transform player;
	public Text cluesBody;

	// Use this for initialization
	void Start () {
		showCaseFiles ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void showCaseFiles() {
		canvas.gameObject.SetActive (true);
		canvas.position = player.GetChild (0).position + player.GetChild (0).forward * 3f;
		canvas.rotation = player.GetChild (0).rotation;
		//string body = PlayerPrefs.GetString ("cluesbody1");
		this.cluesBody.text = "Hola - Hello - Aloha \nPatos y Conejos\n Arturo es la toxina";
	}

	public void showCaseFile() {
		Debug.Log ("case file");
	}
}
