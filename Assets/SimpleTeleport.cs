using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTeleport : MonoBehaviour {

    private GlueToHeadset headSetScript;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(GvrControllerInput.ClickButtonDown){
            GameObject controller = GameObject.Find("CubeController");
            headSetScript = controller.GetComponent<GlueToHeadset>();

            if(headSetScript.target != null) {
                this.transform.position = headSetScript.hitPoint + new Vector3(0f, 5f, 0f);
            }
        }
	}
}
