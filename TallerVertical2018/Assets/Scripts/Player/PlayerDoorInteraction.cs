using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDoorInteraction : MonoBehaviour {

	private bool colliding;
	private CharacterController controller;
	// Use this for initialization
	void Start () {
		this.controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.controller.collisionFlags == CollisionFlags.Below) {
			this.colliding = false;
		}
	}

	void OnControllerColliderHit (ControllerColliderHit hit) {
		
		if (hit.gameObject.tag == "Door") {
			if (isActive(hit.gameObject.GetComponent<DoorController>()) && !colliding && hit.gameObject.GetComponent<DoorController> ().isGazed) {
				PlayerPrefs.SetString ("NextSceneToLoad", hit.gameObject.GetComponent<DoorController>().sceneToLoad);
				SceneManager.LoadScene ("LoadingScreen", LoadSceneMode.Single);
				this.colliding = true;
			}
		}
	}

	bool isActive(DoorController door) {
		if (door.dependsOn == null) {
			return true;
		} else if(door.dependsOn.Length == 0) {
			return true;
		}
		for (int i = 0; i < door.dependsOn.Length; i++) {
			if(door.dependsOn [i] != null && PlayerPrefs.GetInt (door.dependsOn [i].transform.name + "Collected", 0) == 0) {
				return false;
			}
		}
		return true;
	}
}
