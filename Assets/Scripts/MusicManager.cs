using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public static MusicManager instance;

	public AudioClip levelMusic;
	public AudioClip inmuneMusic;

	private AudioSource musicSource;
    
    void Awake()
    {
        instance = this;
    }
    
    // Use this for initialization
	void Start () {

        musicSource = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeMusic(AudioClip music)
    {
        musicSource.Stop();
        musicSource.clip = music;
        musicSource.Play();
    }

}
