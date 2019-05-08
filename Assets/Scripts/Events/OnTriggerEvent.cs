using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class OnTriggerEvent : MonoBehaviour
{
	string hitTag = "Player";
	public UnityEvent onEnter;

	void OnTriggerEnter(Collider other) {
		if (other.tag == hitTag) {
			onEnter.Invoke();
		}
	}
}
