using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCatLife2 : MonoBehaviour {

	private GlueToHeadset headSetScript;
	private GameObject cameraObject;
	private GameObject selfRigidbody;
	private bool canJump = true;

	void Start(){
		//selfRigidbody = GetComponent<RigidBody>();
		cameraObject = GameObject.Find("Main Camera");
	}


	// Update is called once per frame
	void Update () {

		if (canJump == true && (GvrControllerInput.ClickButtonDown || Input.GetKeyDown("space"))) {
			this.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 10f, 0), ForceMode.Impulse);
			Debug.Log ("Jumping");
			canJump = false;
		}

		if (Input.GetKey("up")) {
			this.transform.Translate(cameraObject.transform.forward * 0.1f);
		}
		if (Input.GetKey("down")) {
			this.transform.Translate(cameraObject.transform.forward * -0.1f);
		}
		if (Input.GetKey("left")) {
			cameraObject.transform.Rotate (Vector3.up * -0.4f);
		}
		if (Input.GetKey("right")) {
			cameraObject.transform.Rotate (Vector3.up * 0.4f);
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

	void OnCollisionEnter(Collision other) {
		Debug.Log ("Collisioned!");
		canJump = true;
	}
}
