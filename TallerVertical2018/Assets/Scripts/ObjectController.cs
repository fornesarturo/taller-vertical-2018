﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour {

	private bool selected;
	public Material selectedMaterial;
	public Material normalMaterial;
	public string Clue;
	public string Case;

	[SerializeField] private Text itemName;
	[SerializeField] private Text itemDescription;

	[SerializeField] private GameObject canvasDescription;
	[SerializeField] private Transform Player;

	void Awake() {
		Player = GameObject.FindGameObjectWithTag ("Player").transform;
		PlayerPrefs.SetInt (transform.parent.name + "Collected", 0);
	}

	// Use this for initialization
	void Start () {
		int collected = PlayerPrefs.GetInt (transform.parent.name + "Collected", 0);
		if (collected == 1) {
			Destroy (transform.parent.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (selected) {
			//canvasDescription.transform.position = Player.GetChild(0).position + new Vector3(0,-0.4f,0) + (Player.GetChild(0).forward * 2);

			Vector3 canvasPosition = Player.GetChild(0).position + (Player.GetChild(0).forward * 2) + (Player.GetChild(0).up * -0.4f);
			canvasDescription.transform.position = Vector3.Lerp (canvasDescription.transform.position, canvasPosition, 5f * Time.deltaTime);
			canvasDescription.transform.rotation = Player.GetChild (0).rotation;
		}

		if (this.selected && Input.GetAxis ("Use") == 1) {
			if (Clue != null) {
				string currentJson = PlayerPrefs.GetString(Case + "Clues", "");
				CaseFileClues currentClues;
				if (currentJson.Length > 0) {
					currentClues = JsonUtility.FromJson<CaseFileClues> (currentJson);
					List<string> currentList = new List<string> (currentClues.clues);
					currentList.Add (Clue);
					currentClues.clues = currentList.ToArray ();
					PlayerPrefs.SetString (Case + "Clues", currentClues.ToString ());
				} else {
					currentClues = new CaseFileClues ();
					currentClues.clues = new string[1]{ Clue };
					PlayerPrefs.SetString (Case + "Clues", currentClues.ToString ());
				}
			}
			PlayerPrefs.SetInt (transform.parent.name + "Collected", 1);
			canvasDescription.SetActive (false);
			Destroy (transform.parent.gameObject);
		}
	}

	public void SetSelected (bool selected) {
		this.selected = selected;
		if (selected) {
			canvasDescription.transform.position = Player.GetChild(0).position + new Vector3(0,-0.4f,0) + (Player.GetChild(0).forward * 2);
			itemDescription.text = Clue;
			itemName.text = this.transform.name;
			canvasDescription.SetActive (true);
		} else {
			canvasDescription.SetActive (false);
		}
	}
}
