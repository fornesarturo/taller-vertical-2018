using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoorInteraction : MonoBehaviour {

	private bool colliding;
	private CharacterController controller;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.collisionFlags == CollisionFlags.Below) {
			this.colliding = false;
		}
	}

	void OnControllerColliderHit (ControllerColliderHit hit) {
		if (hit.gameObject.tag == "Door") {
			// DO something
			//hit.gameObject.GetComponent<DoorController>().myName

			if (!colliding && hit.gameObject.GetComponent<DoorController>().isGazed) {
				Debug.Log( "Enter to house..." );
				this.colliding = true;
			}	
		}
	}
}
