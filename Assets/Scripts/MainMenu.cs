﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void Quit(){
		Application.Quit();
	}

	public void Play(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

}
