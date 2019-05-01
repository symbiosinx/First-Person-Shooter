using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour {

	public bool cursorHidden = true;
	public float minYAngle = -80f, maxYAngle = 80f;
	public Vector2 speed = new Vector2(120f, 120f);

	Vector2 euler;

	void Start() {
		
		if (cursorHidden) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		euler = transform.eulerAngles;
	}

	void Update() {

		euler.y += Input.GetAxis("Mouse X") * speed.x * Time.deltaTime;
		euler.x -= Input.GetAxis("Mouse Y") * speed.y * Time.deltaTime;

		euler.x = Mathf.Clamp(euler.x, minYAngle, maxYAngle);

		transform.parent.localEulerAngles = Vector3.up * euler.y;
		transform.localEulerAngles = Vector3.right * euler.x;
	}
}
