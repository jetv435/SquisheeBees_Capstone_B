using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour {

	//Playing & stopping music variables
	public AudioSource wrongnote;
	public AudioSource correctnote;
	GameObject MCamera;
	AudioSource Maudio;

	// Use this for initialization
	void Start () {

		MCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		Maudio = MCamera.GetComponent<AudioSource> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayCorrect()
	{
		if (Maudio.isPlaying == true) {
			Maudio.Pause ();
			correctnote.Play ();
		}
	}

	public void PlayWrong()
	{
		if (Maudio.isPlaying == true) {
			Maudio.Pause ();
			wrongnote.Play ();
		}
	}
}
