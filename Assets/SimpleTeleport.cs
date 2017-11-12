﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTeleport : MonoBehaviour {

    private GlueToHeadset headSetScript;
    private GameObject cameraObject;
    // Use this for initialization
    void Start () {
		cameraObject = GameObject.Find("Main Camera");
    }
	
	// Update is called once per frame
	void Update () {

        

        if (GvrControllerInput.ClickButtonDown){
            Vector2 touchPos = GvrControllerInput.TouchPos;
            GameObject controller = GameObject.Find("CubeController");
            Debug.Log((Mathf.Pow((float)touchPos.x - 0.5f, 2) + Mathf.Pow((float)touchPos.y - 0.5f, 2)));
            if ((Mathf.Pow((float)touchPos.x - 0.5f, 2) + Mathf.Pow((float)touchPos.y - 0.5f, 2)) <= 0.05) {
                headSetScript = controller.GetComponent<GlueToHeadset>();

                if (headSetScript.target != null)
                {
                    this.transform.position = headSetScript.hitPoint + new Vector3(0f, 5f, 0f);
                }
            }
        }

        if(GvrControllerInput.IsTouching)
        {
            Vector2 touchPos = GvrControllerInput.TouchPos;
            if ((Mathf.Pow((float)touchPos.x - 0.5f, 2) + Mathf.Pow((float)touchPos.y - 0.5f, 2)) > 0.05)
            {
                float xVel = (touchPos.x - 0.5f) * Time.deltaTime * 15f;
                float zVel = (0.5f - touchPos.y) * Time.deltaTime * 15f;
                Vector3 forward = cameraObject.transform.TransformDirection(new Vector3(xVel, 0, zVel));
                this.transform.Translate(new Vector3(forward.x, 0f, forward.z)); //
                //this.transform.position += new Vector3(xVel, 0, zVel);
            }
        }
	}
}
