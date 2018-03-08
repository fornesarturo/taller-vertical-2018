using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSmellVision : MonoBehaviour {

	private Transform Player;

	void Awake () {

		Player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void enableSmell() {
		Player.gameObject.GetComponent<SmellVision> ().enabled = true;
		Player.position = this.transform.position;
		Player.rotation = this.transform.rotation;
		Destroy (this.gameObject);
	}
}
