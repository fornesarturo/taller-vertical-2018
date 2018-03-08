using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPrefabs : MonoBehaviour {

	void Awake() {
		PlayerPrefs.SetInt ("ObjectCollected", 0);
	}

	// Use this for initialization
	void Start () {
		//PlayerPrefs.SetInt ("ObjectCollected", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
