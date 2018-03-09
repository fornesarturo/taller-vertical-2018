using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMov : MonoBehaviour {

	// Use this for initialization
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private AudioSource steps;
	private float roty;
	private Vector3 moveDirection = Vector3.zero;
	private Quaternion rotation;
	private CharacterController controller;
	public bool moveOnStart;

	void Awake(){
		this.controller = GetComponent<CharacterController>();
		this.steps = GetComponent<AudioSource> ();
		steps.volume = 0.2f;
		steps.pitch=PlayerPrefs.GetFloat ("pitch", 1);
		//this.controller.enabled = moveOnStart;
		//PlayerPrefs.SetInt (SceneManager.GetActiveScene ().name + "dialog", 0);
	}

	void Start () {
		
	}

	void Update () {
		if (!steps.isPlaying && (Mathf.Abs (Input.GetAxis ("Vertical")) + Mathf.Abs (Input.GetAxis ("Horizontal"))) > 0.1f) {
			steps.Play ();
		} else if (steps.isPlaying && (Mathf.Abs (Input.GetAxis ("Vertical")) + Mathf.Abs (Input.GetAxis ("Horizontal"))) < 0.1f) {
			steps.Stop ();
		}

		if (this.controller.isGrounded) {
			moveDirection = transform.GetChild (0).transform.forward * Input.GetAxis ("Vertical");
			moveDirection += transform.GetChild (0).transform.right * Input.GetAxis ("Horizontal");
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
		}
		moveDirection.y -= gravity * Time.deltaTime;
		this.controller.Move(moveDirection * Time.deltaTime);
	}
}
