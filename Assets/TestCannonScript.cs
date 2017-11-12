using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCannonScript : MonoBehaviour {

    public GameObject CannonBall;
    public Transform CannonEnd;

    float timer = 0f;
    float ShootTreshold = 15f;
    bool shot = false;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > ShootTreshold && shot == false)
        {
            CannonShoot();
            shot = true;
        }
    }

    void CannonShoot() {
        GameObject newCannonBall = Instantiate(CannonBall, CannonEnd.transform.position, CannonEnd.transform.rotation);
        Rigidbody crb = newCannonBall.GetComponent<Rigidbody>();
        crb.AddForce(CannonEnd.transform.forward * 900);

        GameObject headset = GameObject.Find("Headset");
        headset.transform.SetParent(crb.transform);
    }
}
