using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallScript : MonoBehaviour {

    public Rigidbody rb;

    bool cameraFollow = false;
    GameObject headset;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        cameraFollow = false;
        headset = GameObject.Find("Headset");
    }
	
	// Update is called once per frame
	void Update () {
        float direction = rb.velocity.y;
        if(this.transform.position.y < 20 && direction < 0) {
            disconnectHeadSet();
            cameraFollow = true;
        }

        if(cameraFollow) {
            //headset.transform.LookAt(this.transform);
        }
	}

    void disconnectHeadSet() {
        headset.transform.parent = null;
    }
}
