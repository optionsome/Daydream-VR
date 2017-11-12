using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigidBodyScoreScript : MonoBehaviour {

    private Rigidbody rb;
    bool fatalFalling = false;
    public float velocityTreshold = 15f;
    public string objectName = "Plate";

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        fatalFalling = false;
    }
	
	// Update is called once per frame
	void Update () {

        float normalizedVelocity = Mathf.Sqrt( rb.velocity.x * rb.velocity.x + rb.velocity.y * rb.velocity.y + rb.velocity.z * rb.velocity.z);

        if(normalizedVelocity > velocityTreshold) {
            fatalFalling = true;
        }
    }

    void OnTriggerEnter(Collider other) {
        if(fatalFalling) {
            // Could be used!
            var explosion = GetComponent<ParticleSystem>();
            explosion.Play();
            updateGameScore();
            Destroy(gameObject, explosion.main.duration);
        }
    }

    void updateGameScore() {
        scoreUiText scoreScript = GameObject.Find("ScoreText").GetComponent<scoreUiText>();
        scoreScript.updateCurrentScore(100, objectName);
    }
}
