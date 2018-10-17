using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour {

    [SerializeField] private LayerMask layerClickleable;
    [SerializeField] private EventVector3 onClickEnviroment;

    private RaycastHit mouseHit;


    private Vector3 mousePosition;

    private Interactable interaction;

	void Start () {
		
	}
	

	void Update () {
        mousePosition = Input.mousePosition;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(mousePosition),out mouseHit,50f,layerClickleable) ) {
            if (Input.GetMouseButtonDown(0)) {
                Debug.Log(mouseHit.collider.name);
                interaction = mouseHit.collider.GetComponent<Interactable>();
                if (interaction!=null) {
                    Debug.Log("Follow");
                    Player.instance.followTarget(interaction);
                }
                else {
                    Player.instance.stopFollowTarget();
                    onClickEnviroment.Invoke(mouseHit.point);
                }
            }
        }
	}
}
[System.Serializable]
public class EventVector3 : UnityEvent<Vector3> { }