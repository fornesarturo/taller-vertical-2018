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

	void Start(){

	}


	void Update() {
		CharacterController controller = GetComponent<CharacterController>();


		if (controller.isGrounded) {

			moveDirection = transform.GetChild (0).transform.forward * Input.GetAxis ("Vertical");
			moveDirection += transform.GetChild (0).transform.right * Input.GetAxis ("Horizontal");
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;

		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

	}
}
