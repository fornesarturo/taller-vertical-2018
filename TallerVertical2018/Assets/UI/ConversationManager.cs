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

    public FileInfo theSourceFile;
    protected StreamReader reader = null;
	public Transform Player;
	public Transform Npc;
	private String[] lines;
	private int i=0;
	private bool doDialog;

		
    // Use this for initialization
    void Start () {
		if (PlayerPrefs.GetInt (SceneManager.GetActiveScene ().name + "dialog",0) == 0) {
			canvas.SetActive (true);
			PlayerPrefs.SetInt (SceneManager.GetActiveScene ().name + "dialog", 1);

			TextAsset level = Resources.Load<TextAsset> (SceneManager.GetActiveScene().name);
			lines = level.text.Split ("\n" [0]);

			Npc.LookAt (Player.position);

			canvas.transform.position = Npc.position + new Vector3 (0, -0.5f, 0) + (Npc.forward * 5);
			canvas.transform.rotation = Npc.rotation;
			canvas.transform.Rotate(0,180,0);

			animalName.text = lines [i];
			conversation.text = lines [++i];
			doDialog = true;
		} else {
			Player.GetComponent<CharacterController>().enabled = true;
		}

    }
	
	// Update is called once per frame
	void Update () {
        updateText();
    }

    void updateText() {
		if (Input.GetButtonDown("Jump")&&doDialog) {	
			if (i < lines.Length-1) {
				animalName.text = lines[++i];
				conversation.text = lines[++i];
			} else {

				canvas.SetActive (false);
				Player.GetComponent<CharacterController>().enabled = true;
			}

        }
    }
}
