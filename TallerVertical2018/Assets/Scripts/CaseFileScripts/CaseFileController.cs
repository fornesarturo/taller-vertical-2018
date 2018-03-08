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

	private string cluesStringFront = "";
	private string cluesStringLeft = "";
	private string cluesStringRight = "";

	// Use this for initialization
	void Start () {
		Player.GetComponent<CharacterController>().enabled = false;
		CaseFileClues cluesTemp;
		// Front
		string jsonFront = PlayerPrefs.GetString ("HouseDemoClues","");
		if (jsonFront != "") {
			cluesTemp = JsonUtility.FromJson<CaseFileClues> (jsonFront);
			for (int i = 0; i < cluesTemp.clues.Length; i++) {
				cluesStringFront += cluesTemp.clues [i];
				if (i < cluesTemp.clues.Length - 1) {
					cluesStringFront += "\n";
				}
			}
		}
		// Left
		string jsonLeft = PlayerPrefs.GetString ("House2Clues","");
		if (jsonLeft != "") {
			cluesTemp = JsonUtility.FromJson<CaseFileClues> (jsonLeft);
			for (int i = 0; i < cluesTemp.clues.Length; i++) {
				cluesStringLeft += cluesTemp.clues [i];
				if (i < cluesTemp.clues.Length - 1) {
					cluesStringLeft += "\n";
				}
			}
		}
		showCaseFiles ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void showCaseFiles() {
		canvas.gameObject.SetActive (true);
		//canvas.position = Player.GetChild (0).position + Player.GetChild (0).forward * 2f;
		//canvas.rotation = Player.GetChild (0).rotation;
		//string body = PlayerPrefs.GetString ("cluesbody1");
		this.cluesBodyLeft.text = cluesStringLeft;
		this.cluesBodyFront.text = cluesStringFront;
		this.cluesBodyRight.text = cluesStringRight;	
	}

	public void showCaseFile() {
		Debug.Log ("case file");
	}
}
