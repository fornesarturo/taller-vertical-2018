using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class ConversationManager : MonoBehaviour {

    public Text animalName;
    public Text conversation;

    public GameObject canvas;

    public FileInfo theSourceFile;
    protected StreamReader reader = null;
	public Transform Player;
	private String[] lines;
	private int i=0;


    // Use this for initialization
    void Start () {
        canvas.SetActive(true);

		TextAsset level = Resources.Load<TextAsset> (PlayerPrefs.GetString ("NextSceneToLoad"));

		lines = level.text.Split ("\n" [0]);

		canvas.transform.position = Player.GetChild(0).position+ new Vector3(0,-0.4f,0) + (Player.GetChild(0).forward*2);
		canvas.transform.rotation = Player.GetChild (0).rotation;

		animalName.text = lines[i];
		conversation.text = lines[++i];

    }
	
	// Update is called once per frame
	void Update () {
        updateText();
    }

    void updateText() {
		if (Input.GetButtonDown("Jump")) {	
			if (i < lines.Length) {
				animalName.text = lines[++i];
				conversation.text = lines[++i];
			} else {
				canvas.SetActive (false);
				Player.GetComponent<CharacterController>().enabled = true;
			}

        }
    }
}
