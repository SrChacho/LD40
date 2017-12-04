using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public Text timeText;
	float time = 0;
	int seconds = 0;
	int minutes = 0;

	string text; 


	// Update is called once per frame
	void Update () {
		time += Time.deltaTime * GameManager.instance.gameSpeed;
		seconds = (int)time;
		//Reset de los segundos sumando 1 a los minutos
		if(seconds >= 60){
			minutes ++;
			seconds = 0;
			time = 0;
		}
		//Formato de texto del timer
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
