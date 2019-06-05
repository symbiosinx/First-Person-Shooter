using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float damage = 1f;
	public float speed = 100f;
	public GameObject effectsPrefab;
	public Transform line;

	Rigidbody rigid;

	void Awake() {
		rigid = GetComponent<Rigidbody>();
	}

	void Update() {
		if (rigid.velocity.magnitude > 0) {
			line.transform.rotation = Quaternion.LookRotation(rigid.velocity);
		}
	}

	void OnCollisionEnter(Collision col) {
		ContactPoint contact = col.contacts[0];
		//Instantiate(effectsPrefab, contact.point, Quaternion.LookRotation(contact.normal));
		Enemy enemy = col.collider.GetComponent<Enemy>();
		if (enemy) {
			enemy.TakeDamage(damage);
		}
		Destroy(gameObject);
	}

	public void Fire(Vector3 lineOrigin, Vector3 direction) {
		rigid.AddForce(direction * speed, ForceMode.Impulse);
		line.transform.position = lineOrigin;
	}
}
