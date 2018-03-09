using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDialogSwitch : MonoBehaviour {
	public GameObject firstDiag;
	// Use this for initialization
	void Start () {
		firstDiag.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Cambio(){
		firstDiag.SetActive (true);
		this.gameObject.SetActive (false);
	}
}
