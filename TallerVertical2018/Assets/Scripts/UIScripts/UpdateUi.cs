using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUi : MonoBehaviour {

    public Text smellVisionStatus;
    public Text currentLocation;

    bool smellVision;

	// Use this for initialization
	void Start () {
        smellVision = false;
        smellVisionStatus.text = "DEACTIVATED";
        smellVisionStatus.color = Color.red;
        currentLocation.text = "My house";
	}
	
	// Update is called once per frame
	void Update () {
        activateSmellVision();
	}

    void activateSmellVision() {
        if (Input.GetKeyDown("space"))
        {
            if (!smellVision) {
                smellVisionStatus.text = "ACTIVATED";
                smellVisionStatus.color = Color.green;
                smellVision = true;
            }
            else {
                smellVisionStatus.text = "DEACTIVATED";
                smellVisionStatus.color = Color.red;
                smellVision = false;
            }
        }
    }
}
