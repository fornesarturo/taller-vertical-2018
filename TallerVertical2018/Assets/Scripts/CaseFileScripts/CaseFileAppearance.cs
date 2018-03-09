using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaseFileAppearance : MonoBehaviour {

    public Transform oscarCanvas;
    public Transform frankCanvas;
    public Transform Player;
    public Button oscarGuilty;
    public Button frankGuilty;

    // Use this for initialization
    void Start () {
        Player.GetComponent<CharacterController>().enabled = false;
        oscarCanvas.gameObject.SetActive(false);
        frankCanvas.gameObject.SetActive(false);
        oscarGuilty.gameObject.SetActive(false);
        frankGuilty.gameObject.SetActive(false);
        makeFilesVisible();
        makeButtonsVisible();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void makeFilesVisible() {
        if (PlayerPrefs.GetInt("Scene_02" + "dialog") == 1) {
            oscarCanvas.gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Scene_05" + "dialog") == 1)
        {
            frankCanvas.gameObject.SetActive(true);
        }
    }

    void makeButtonsVisible() {
        if (PlayerPrefs.GetInt("Scene_05_02" + "dialog") == 1) {
            oscarGuilty.gameObject.SetActive(true);
            frankGuilty.gameObject.SetActive(true);
        }
    }
}