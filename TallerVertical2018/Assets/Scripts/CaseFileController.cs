using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaseFileController : MonoBehaviour {

	public Transform canvas;
	public Transform Player;
	public Text cluesBodyFront;
	public Text cluesBodyLeft;
	public Text cluesBodyRight;

	// Use this for initialization
	void Start () {
		Player.GetComponent<CharacterController>().enabled = false;
		showCaseFiles ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void showCaseFiles() {
		canvas.gameObject.SetActive (true);
		canvas.position = Player.GetChild (0).position + Player.GetChild (0).forward * 2f;
		canvas.rotation = Player.GetChild (0).rotation;
		//string body = PlayerPrefs.GetString ("cluesbody1");
		this.cluesBodyLeft.text = "Left Text";
		this.cluesBodyFront.text = "Front Text";
		this.cluesBodyRight.text = "Right Text";	
	}

	public void showCaseFile() {
		Debug.Log ("case file");
	}
}
