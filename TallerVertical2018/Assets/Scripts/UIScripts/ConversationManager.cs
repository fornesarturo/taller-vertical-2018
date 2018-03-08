using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class ConversationManager : MonoBehaviour {

    public Text animalName;
    public Text conversation;

    public GameObject canvas;
	private Transform Player;

    //public FileInfo theSourceFile;
    //protected StreamReader reader = null;
	//public Transform Npc;

	private String[] lines;
	private int i = 0;
	private bool doDialog;
	private bool selected = false;

	[SerializeField] EnableSmellVision ellenaScript;
	[SerializeField] string conversationTitle;
		
	void Awake () {
		
		Player = GameObject.FindGameObjectWithTag ("Player").transform;
		//PlayerPrefs.SetInt (conversationTitle + "dialog", 0);
	}

    // Use this for initialization
    void Start () {
		
    }
	
	// Update is called once per frame
	void Update () {
		
		if (selected) {

			if (PlayerPrefs.GetInt (conversationTitle + "dialog",0) == 0) {
				
				Player.GetComponent<CharacterController>().enabled = false;
				canvas.SetActive (true);
				PlayerPrefs.SetInt (conversationTitle + "dialog", 1);

				TextAsset level = Resources.Load<TextAsset> (conversationTitle);
				Debug.Log (level);
				lines = level.text.Split ("\n" [0]);

				transform.LookAt (Player.position);

				canvas.transform.position = transform.position + new Vector3 (0, -0.3f, 0) + (transform.forward * 5);
				canvas.transform.rotation = transform.rotation;
				canvas.transform.Rotate(0,180,0);

				animalName.text = lines [i];
				conversation.text = lines [++i];
				doDialog = true;
			} else {
				//Player.GetComponent<CharacterController>().enabled = true;
			}
		}

        updateText();
    }

    void updateText() {
		if (Input.GetButtonDown("Jump")&&doDialog) {	
			if (i < lines.Length-1) {
				animalName.text = lines[++i];
				conversation.text = lines[++i];
			} else {

				canvas.SetActive (false);
				animalName.text = "";
				conversation.text = "";
				Player.GetComponent<CharacterController>().enabled = true;

				if (ellenaScript != null) {
					ellenaScript.enableSmell();
				}
			}

        }
    }

	public void SetSelected(bool selected) {
		this.selected = selected;
	}
}
