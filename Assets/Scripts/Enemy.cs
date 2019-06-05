using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour {

	public float maxHealth = 100f;
	public GameObject healthBarUIPrefab;
	public Transform healthBarParent;
	public Transform healthBarPoint;

	float health = 0;
	Slider healthSlider;
	Renderer rend;

	void Start() {
		health = maxHealth;
		GameObject clone = Instantiate(healthBarUIPrefab, healthBarParent);
		healthSlider = clone.GetComponent<Slider>();
		rend = GetComponent<Renderer>();

	}

	void OnDestroy() {
		if (healthSlider) {
			Destroy(healthSlider.gameObject);
		}
	}

	void LateUpdate() {
		if (rend.isVisible) {
			healthSlider.gameObject.SetActive(true);
			Vector3 screenPosition = Camera.main.WorldToScreenPoint(healthBarPoint.position);
			healthSlider.transform.position = screenPosition;
		} else {
			healthSlider.gameObject.SetActive(false);
		}
	}

	public void TakeDamage(float damage) {
		health -= damage;
		healthSlider.value = health / maxHealth;
		if (health < 0f) {
			Destroy(gameObject);
		}
	}
}
