using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour {

	//Playing & stopping music variables
	public AudioSource wrongnote;
	public AudioSource correctnote;
	GameObject MCamera;
	AudioSource Maudio;

	bool playingCorrect = false;

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
		correctnote.Play ();

	}

	public void PlayWrong()
	{
		if (playingCorrect == false) {
			wrongnote.Play ();
		}

	}

	public void ResumePlay(){
		Maudio.UnPause ();
	}

	public void CorrectSet(bool setVar)
	{
		playingCorrect = setVar;
	}

	public bool CorrectGive()
	{
		return playingCorrect;
	}
		
}
