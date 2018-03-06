using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

	//public GameObject player;
	// attribute to taht defines the scene to load
	public string myName = "hola";
	public bool isGazed;
	public string sceneToLoad = "HouseDemo";

	// Use this for initialization
	void Start () {
		isGazed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isGazed) {
			// highlight door
		}
	}

	public void doorGazed() {
		isGazed = !isGazed;
	}
}
