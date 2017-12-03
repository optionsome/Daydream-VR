using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreUiText : MonoBehaviour {

    Text txt;
    private int currentscore = 0;

    float timer = 0f;
    bool textDisplaying = false;
    float displayTime = 2f;

    List<Color> coolColors = new List<Color>()
    {
        new Color(209, 249, 255),
        new Color(120, 60, 50),
        new Color(80, 140, 103)
    };
    // Use this for initialization
    void Start () {
        txt = gameObject.GetComponent<Text>();
        textDisplaying = false;
        timer = 0f;
    }
	
	// Update is called once per frame
	void Update () {
		
        if(textDisplaying) {
            timer += Time.deltaTime;

            if(timer > displayTime) {
                txt.text = "";
            }
        }
	}

    public void updateCurrentScore(int increase, string brokenObject) {

        txt.color = coolColors[Random.Range(0, coolColors.Count)];

        currentscore += increase;
        txt.text = "Score " + currentscore + " + " + increase;
        textDisplaying = true;
        timer = 0f;
    }
}
