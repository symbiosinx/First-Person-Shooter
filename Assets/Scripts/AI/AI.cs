using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour {

	Vector3 velocity;
	protected float maxVelocity = 5f;
	protected float maxDistance = 5f;
	protected NavMeshAgent agent;
	protected SteeringBehaviour[] behaviours;

	public Vector3 Velocity {
		protected set { velocity = value; }
		get { return velocity; }
	}

	void Update() {
		CalculateForce();
	}

	void Awake() {
		agent = GetComponent<NavMeshAgent>();
		behaviours = GetComponents<SteeringBehaviour>();
	}

	public virtual Vector3 CalculateForce() {
		Vector3 force = Vector3.zero;

		foreach (var behaviour in behaviours) {
			force += behaviour.GetForce() * behaviour.weighting;
			if (force.magnitude > maxVelocity) {
				force = force.normalized * maxVelocity;
				break;
			}
		}

		velocity += force * Time.deltaTime;

		if (velocity.magnitude > maxVelocity) {
			velocity = velocity.normalized * maxVelocity;
		}

		if (velocity.magnitude > 0) {
			Vector3 pos = transform.position + velocity * Time.deltaTime;
			NavMeshHit hit;
			if (NavMesh.SamplePosition(pos, out hit, maxDistance, -1)) {
				agent.SetDestination(hit.position);
			}
		}
		return force;
	}

}
