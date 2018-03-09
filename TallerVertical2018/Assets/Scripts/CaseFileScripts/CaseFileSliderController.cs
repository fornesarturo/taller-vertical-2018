using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaseFileSliderController : MonoBehaviour {

	private Slider slider;
	private bool isGazed;

	// Use this for initialization
	void Start () {
		slider = this.GetComponent<Slider> ();
		isGazed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isGazed) {
			
			float verticalMovement = Input.GetAxis ("Vertical");
			if (verticalMovement > 0) {
				
				slider.value += 0.01f;

			} else if (verticalMovement < 0) {
				
				slider.value -= 0.01f;
			}
			string caseName = this.transform.parent.parent.parent.name;
			string sliderName = this.gameObject.name;
			string sliderKeyName = caseName + sliderName;
			Debug.Log (sliderKeyName);
			if (PlayerPrefs.GetInt (sliderKeyName) != slider.value) {
				PlayerPrefs.SetInt ( sliderKeyName, (int)Mathf.Floor(slider.value * 10) );
				Debug.Log (PlayerPrefs.GetInt (sliderKeyName));
				Debug.Log (sliderKeyName);
			}
			//Debug.Log (slider.value);

			//PlayerPrefs.SetInt ("", slider.value);
		}
		//Debug.Log (this.transform.parent.parent.parent.transform.name + " : " + Mathf.Floor(slider.value * 10));
		//Debug.Log(slider.value);
		//this.transform.parent.transform.name;
	}

	public void isBeingGazed() {
		isGazed = !isGazed;
	}
}
