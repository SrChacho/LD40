using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

    public float score = 0;
    public float gameSpeed = 1;
    public Text scoreText;
    
    void Awake()
    {
        instance = this;
    }
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeScore(float quantity)
    {
        score += quantity;
        scoreText.text = score.ToString("0000");
    }

    public void GameOver()
    {
        print("Game Over");
    }

}
