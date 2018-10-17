using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    [SerializeField] private float interactionRadius = 3f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(this.transform.position,interactionRadius);
    }

    public float getInteractionRadius() {
        return interactionRadius;
    }


}
