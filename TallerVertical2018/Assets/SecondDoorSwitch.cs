using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondDoorSwitch : MonoBehaviour {
	public GameObject door;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void EnableDoor(){
		door.GetComponent<DoorController> ().enabled = true;
		this.gameObject.SetActive (false);
	}
}
