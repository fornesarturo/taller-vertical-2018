using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingController : MonoBehaviour {

	public Button exitButton;

	private int oscarHonesty;
	private int oscarEmpathy;
	private int oscarGuilt;
	private int oscarAppearance;

	private int frankHonesty;
	private int frankEmpathy;
	private int frankGuilt;
	private int frankAppearance;

	// Use this for initialization
	void Start () {
		StartCoroutine ("ShowButton");
		oscarHonesty = PlayerPrefs.GetInt("CaseFilesOscarHonesty",0);
		oscarEmpathy = PlayerPrefs.GetInt("CaseFilesOscarEmpathy",0);
		oscarGuilt = PlayerPrefs.GetInt("CaseFilesOscarGuilt",0);
		oscarAppearance = PlayerPrefs.GetInt("CaseFilesOscarAppearance",0);

		frankHonesty = PlayerPrefs.GetInt("CaseFilesFrankHonesty",0);
		frankEmpathy = PlayerPrefs.GetInt("CaseFilesFrankEmpathy",0);
		frankGuilt = PlayerPrefs.GetInt("CaseFilesFrankGuilt",0);
		frankAppearance = PlayerPrefs.GetInt("CaseFilesFrankAppearance",0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator ShowButton() {
		yield return new WaitForSecondsRealtime (2.5f);
		exitButton.transform.gameObject.SetActive (true);
	}
}
