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
		
	}

	public void SetSelected(bool selected) {
		this.selected = selected;
		renderer.material = selected ? selectedMaterial: normalMaterial;
	}
}
