using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashObjectController : MonoBehaviour {

	private bool selected;
	public string Clue;

	[SerializeField] private Text itemName;
	[SerializeField] private Text itemDescription;

	[SerializeField] private GameObject canvasDescription;
	private Transform Player;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player").transform;
		PlayerPrefs.SetInt (transform.parent.name + "Collected", 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (selected) {
			//canvasDescription.transform.position = Player.GetChild(0).position + new Vector3(0,-0.4f,0) + (Player.GetChild(0).forward * 2);

			Vector3 canvasPosition = Player.GetChild(0).position + (Player.GetChild(0).forward * 2) + (Player.GetChild(0).up * -0.4f);
			canvasDescription.transform.position = Vector3.Lerp (canvasDescription.transform.position, canvasPosition, 5f * Time.deltaTime);
			canvasDescription.transform.rotation = Player.GetChild (0).rotation;
		}
	}

	public void SetSelected (bool selected) {
		this.selected = selected;
		if (selected) {
			canvasDescription.transform.position = Player.GetChild(0).position + new Vector3(0,-0.4f,0) + (Player.GetChild(0).forward * 2);
			itemDescription.text = Clue;
			itemName.text = this.transform.name;
			canvasDescription.SetActive (true);
		} else {
			canvasDescription.SetActive (false);
		}
	}
}
