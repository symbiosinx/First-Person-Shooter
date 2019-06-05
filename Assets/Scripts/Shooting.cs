using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	public Weapon currentWeapon;

	void Start() {

	}


	void Update() {
		if (currentWeapon) {
			if (Input.GetButton("Fire1")) {
				if (currentWeapon.canShoot) {
					currentWeapon.Shoot();
				}
			}
		}
	}
}
