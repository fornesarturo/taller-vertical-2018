using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour {



	// Use this for initialization
	void Start () {
		StartCoroutine ("LoadNewScene");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator LoadNewScene() {

		//yield return new WaitForSeconds (2f);

		AsyncOperation async = SceneManager.LoadSceneAsync("VRInteraction");

		//async.pr

		yield return async;
	}
}
