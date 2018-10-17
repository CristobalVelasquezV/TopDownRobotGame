using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {
    private Animator robotAnimator;
    private NavMeshAgent robotNavAgent;

    public static Player instance;

    private int speedHash;

    private Transform target;

	void Awake () {
        if (instance == null) {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        robotAnimator = GetComponent<Animator>();
        robotNavAgent = GetComponent<NavMeshAgent>();

        speedHash = Animator.StringToHash("Speed");

    }
	
	void Update () {
        if (target != null) {
            moveToPoint(target.position);
        }
        robotAnimator.SetFloat(speedHash,robotNavAgent.velocity.magnitude);
	}

    public void moveToPoint(Vector3 destination) {
        robotNavAgent.SetDestination(destination);
    }

    public void followTarget(Interactable newTarget) {
        float distance = (this.transform.position - newTarget.transform.position).magnitude;
        if (newTarget.getInteractionRadius()>=distance) {
            target = newTarget.transform;
        }
    }
    public void stopFollowTarget() {
        target = null;
    }

    public void endDialogue() {

    }
}
