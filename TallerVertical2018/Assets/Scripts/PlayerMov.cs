using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour {

	// Use this for initialization
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private float roty;
	private Vector3 moveDirection = Vector3.zero;
	private Quaternion rotation;
	private CharacterController controller;

	void Start () {
		this.controller = GetComponent<CharacterController>();
		this.controller.enabled = true;
	}

	void Update () {
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
