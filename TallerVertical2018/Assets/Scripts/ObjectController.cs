using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {
	
	private bool selected;
	public Material selectedMaterial;
	public Material normalMaterial;
	private Renderer renderer;
	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.selected && Input.GetAxis ("Use") == 1) {
			Debug.Log ("Selected item: " + transform.name);
			Destroy (transform.gameObject);
		}
	}

	public void SetSelected(bool selected) {
		this.selected = selected;
		renderer.material = selected ? selectedMaterial: normalMaterial;
	}
}
