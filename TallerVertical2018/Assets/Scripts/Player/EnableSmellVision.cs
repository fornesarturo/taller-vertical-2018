using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSmellVision : MonoBehaviour {

	private Transform Player;

	void Awake () {

		Player = GameObject.FindGameObjectWithTag ("Player").transform;
		//PlayerPrefs.SetInt ("ellenaDead", 0);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("ellenaDead") == 1) {
			Destroy (this.gameObject);
		}
	}

	public void enableSmell() {
		Player.gameObject.GetComponent<SmellVision> ().enabled = true;
		Player.position = this.transform.position + new Vector3 (0, 8f, 0);
		//Player.rotation = this.transform.rotation;
		PlayerPrefs.SetInt ("ellenaDead", 1);
		Destroy (this.gameObject);
	}
}
