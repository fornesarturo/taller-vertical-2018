using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoorInteraction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnControllerColliderHit (ControllerColliderHit hit) {
		if (hit.gameObject.tag == "Door") {
			// DO something
			//hit.gameObject.GetComponent<DoorController>().myName 
			if (hit.gameObject.GetComponent<DoorController>().isGazed) {
				Debug.Log( "Enter to house..." );
			}	
		}
	}
}
