using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectController : MonoBehaviour {

	private bool selected;
	public Material selectedMaterial;
	public Material normalMaterial;
	private Renderer renderer;
	public string Clue;
	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
		int collected = PlayerPrefs.GetInt (transform.name + "Collected", 0);
		if (collected == 1) {
			Destroy (transform.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (this.selected && Input.GetAxis ("Use") == 1) {
			string sceneName = SceneManager.GetActiveScene ().name;
			if (Clue != null) {
				string currentJson = PlayerPrefs.GetString(sceneName + "Clues", "");
				CaseFileClues currentClues;
				if (currentJson.Length > 0) {
					currentClues = JsonUtility.FromJson<CaseFileClues> (currentJson);
					List<string> currentList = new List<string> (currentClues.clues);
					currentList.Add (Clue);
					currentClues.clues = currentList.ToArray ();
					PlayerPrefs.SetString (sceneName + "Clues", currentClues.ToString ());
				} else {
					currentClues = new CaseFileClues ();
					currentClues.clues = new string[1]{ Clue };
					PlayerPrefs.SetString (sceneName + "Clues", currentClues.ToString ());
				}
			}
			PlayerPrefs.SetInt (transform.name + "Collected", 1);
			Destroy (transform.gameObject);
		}
	}

	public void SetSelected (bool selected) {
		this.selected = selected;
		renderer.material = selected ? selectedMaterial: normalMaterial;
	}

	public void Selected () {
		Debug.Log ("Button Clicked!");
		renderer.material = normalMaterial;
	}
}
