using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

    public float score = 0;
    public float gameSpeed = 1;
    public Text scoreText;
    public GameObject cup;
    
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
        GameObject player = GameObject.Find("Player");
        Vector2 pos = player.transform.position;
        Destroy(player.gameObject);
        GameObject cupInstance = Instantiate(cup, pos, new Quaternion(0,0,0,0));
        cupInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 20, ForceMode2D.Impulse);
        Invoke("StopGame", 1.12f);
    }

    void StopGame(){
        gameSpeed = 0;
    }

}
