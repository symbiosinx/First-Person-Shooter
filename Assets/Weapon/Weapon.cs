using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public int damage = 10, maxReserve = 500, maxClip = 30;
	public float spread = 2f, recoil = 1f, range = 10f, shootRate = 0.2f;
	public Transform shotOrigin;
	public GameObject bulletPrefab;
	public bool canShoot = false;

	private int currentReserve = 0, currentClip = 0;
	private float shootTimer = 0f;
	
	void Start() {
		Reload();
	}

	void Update() {
		shootTimer += Time.deltaTime;
		if (shootTimer >= shootRate) {
			canShoot = true;
		}
	}

	void Reload() {
		if (currentReserve > 0) {
			if (currentReserve >= maxClip) {
				currentReserve -= maxClip + currentClip;
			} else {
				int tempMag = currentReserve;
				currentClip = tempMag;
				currentReserve = tempMag;
			}
		}
	}

	public void Shoot() {
		currentClip--;
		shootTimer = 0f;
		canShoot = false;
		Camera attachedCamera = Camera.main;
		Transform camTransform = attachedCamera.transform;

		Vector3 bulletOrigin = camTransform.position;
		Quaternion bulletRotation = camTransform.rotation;

		Vector3 lineOrigin = shotOrigin.position;
		Vector3 direction = camTransform.forward;

		GameObject clone = Instantiate(bulletPrefab, bulletOrigin, bulletRotation);
		Bullet bullet = clone.GetComponent<Bullet>();
		bullet.Fire(lineOrigin, direction);

	}
}
