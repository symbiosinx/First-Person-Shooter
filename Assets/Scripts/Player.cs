using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	float runSpeed = 10f;
	float walkSpeed = 6f;
	float gravity = -15f;
	float jumpHeight = 6f;
	float groundRayDistance = 1.1f;

	float FOVmax = 110f;
	float FOVmin = 90f;

	CharacterController controller;
	Vector3 motion;
	float speed;

	bool isRunning = false;
	bool isGrounded = true;

	void Start() {
		
		controller = GetComponent<CharacterController>();
		speed = walkSpeed;
	}

	void Update() {

		isGrounded = Physics.Raycast(transform.position, -transform.up, groundRayDistance);


		float inputH = Input.GetAxis("Horizontal");
		float inputV = Input.GetAxis("Vertical");

		motion.x = inputH * speed;
		motion.z = inputV * speed;

		motion = transform.rotation * motion;

		if (isGrounded && Input.GetKey(KeyCode.Space)) {
			motion.y = jumpHeight;
		}

		if (isGrounded && motion.y <= 0f) {
			motion.y = 0f;
		} else {
			motion.y += gravity * Time.deltaTime;
		}

		isRunning = (Input.GetKey(KeyCode.LeftShift) && inputV > 0f) || (isRunning && !isGrounded);

		if (isRunning) {
			speed = runSpeed;
			Camera.main.fieldOfView += 100 * Time.deltaTime;
			Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, FOVmin, FOVmax);
		} else {
			speed = walkSpeed;
			Camera.main.fieldOfView -= 100 * Time.deltaTime;
			Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, FOVmin, FOVmax);
		}



		controller.Move(motion * Time.deltaTime);
	}
}
