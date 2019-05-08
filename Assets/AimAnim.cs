using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAnim : MonoBehaviour {

	public Animator[] anim;


	void Update() {
		if (Input.GetKey(KeyCode.H)) {
			anim[0].SetBool("isAiming", true);

		}
		else if (Input.GetKeyUp(KeyCode.H)) {
			anim[0].SetBool("isAiming", false);

		}
	}
}
