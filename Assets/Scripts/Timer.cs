using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public Text timeText;
	float time = 0;
	int seconds = 0;
	int minutes = 0;
	public float totalTime;

	string text; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		totalTime = Time.deltaTime * GameManager.instance.gameSpeed;
		time += Time.deltaTime * GameManager.instance.gameSpeed;
		seconds = (int)time;

		if(seconds >= 60){
			minutes ++;
			seconds = 0;
			time = 0;
		}

		if(seconds < 10){
			text = minutes + ":0" + seconds;
		}
		if(minutes < 10){
			text = "0" + minutes + ":" + seconds;
		}

		if(seconds < 10 && minutes < 10){
			text = "0" + minutes + ":0" + seconds;
		}

		timeText.text = text;
	}
}
