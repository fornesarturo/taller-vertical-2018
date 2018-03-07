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

    // Use this for initialization
    void Start () {

        canvas.SetActive(true);
		Player.GetComponent<CharacterController>().enabled = false;

		theSourceFile = new FileInfo("Assets/Assests/Dialogs/" + PlayerPrefs.GetString("NextSceneToLoad")+ ".txt");

        reader = theSourceFile.OpenText();
		canvas.transform.position = Player.GetChild(0).position+ new Vector3(0,-0.4f,0) + (Player.GetChild(0).forward*2);
		canvas.transform.rotation = Player.GetChild (0).rotation;

		animalName.text = reader.ReadLine();
		conversation.text = reader.ReadLine();

    }
	
	// Update is called once per frame
	void Update () {
        updateText();
    }

    void updateText() {
        if (Input.GetKeyDown("space")) {	
			if (reader.EndOfStream) {
				canvas.SetActive (false);
				Player.GetComponent<CharacterController> ().enabled = true;
			}
			if (!canvas.activeInHierarchy & !reader.EndOfStream) {
				canvas.SetActive (true);
			}
            animalName.text = reader.ReadLine();
            conversation.text = reader.ReadLine();

        }
    }
}
