﻿using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour {

	NavMeshAgent agent;
	Transform target;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	private void Update()
	{
		if(target!=null)
		{
			agent.SetDestination(target.position);
			FaceTarget();
		}
	}

	private void FaceTarget()
	{
		Vector3 direction = (target.position - transform.position).normalized;

		Quaternion lookrotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

		transform.rotation = Quaternion.Slerp(transform.rotation, lookrotation, Time.deltaTime * 5f);
	}

	public void MoveToPoint (Vector3 point) {

		agent.SetDestination(point);
	}

	public void FollowTarget(Interactable newTarget)
	{
		agent.stoppingDistance = newTarget.radius * .8f;
		agent.updateRotation = false;
		target = newTarget.interactionTransform;
	}

	public void StopFolowingTarget()
	{
		agent.stoppingDistance = 0;
		agent.updateRotation = true;

		target = null;
	}
}
