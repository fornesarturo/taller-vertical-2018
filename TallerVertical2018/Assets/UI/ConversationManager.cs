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

    // Use this for initialization
    void Start () {

        canvas.SetActive(false);
        theSourceFile = new FileInfo("ConvoDePrueba.txt");
        reader = theSourceFile.OpenText();

    }
	
	// Update is called once per frame
	void Update () {
        updateText();
    }

    void updateText() {
        if (Input.GetKeyDown("space")) {
            if (reader.EndOfStream)
                canvas.SetActive(false);
            if (!canvas.activeInHierarchy & !reader.EndOfStream)
                canvas.SetActive(true);
            animalName.text = reader.ReadLine();
            conversation.text = reader.ReadLine();

        }
    }
}
