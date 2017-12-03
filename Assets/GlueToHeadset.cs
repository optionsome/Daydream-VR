using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlueToHeadset : MonoBehaviour {


    public GameObject target;
    public Vector3 hitPoint;
    public Transform HeadsetLoc;

    public GameObject pointerDot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Vector3 forwardF = HeadsetLoc.position + HeadsetLoc.forward * 2f;
        //this.transform.position = new Vector3(forwardF.x + 3f, forwardF.y -0.3f, forwardF.z);
		this.transform.position = HeadsetLoc.position + HeadsetLoc.forward * 2f + HeadsetLoc.right * 1f - HeadsetLoc.up * 0.5f;

        //this.transform.rotation = HeadsetLoc.rotation;
        // Update rotation toi match the controller
        this.transform.localRotation = GvrControllerInput.Orientation;

        isControllerPointingGameObject();
	}

    void isControllerPointingGameObject() {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if(Physics.Raycast(transform.position, fwd, out hit, 40)) {
            target = hit.collider.gameObject;
            hitPoint = hit.point;

            //pointerDot.SetActive(true);
            //pointerDot.transform.position = hitPoint;
        }
        else {
            //pointerDot.SetActive(false);
            target = null;
            hitPoint = Vector3.zero;
        }
    }
}
