﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	private FadeManager fm;
	public CanvasGroup FadeInOutPanel;
	public CanvasGroup Introfade;
	//public int previous;
	public int nextroom;

	void Awake(){
		fm = GameObject.FindGameObjectWithTag ("FadeManager").GetComponent<FadeManager> ();
	}

	void Start(){

		StartCoroutine (Fadeout ());
	}
		

	public void QuitGame(){
		Application.Quit ();
	}

	//public void StartGame(){
		//StartCoroutine (SGCorutine ());
	//}

	//void OnTriggerEnter(Collider other){
		//StartCoroutine (SGCorutine());

	//}


	public IEnumerator Transition(){
		fm.FadeIn (FadeInOutPanel, 60, .5f);
		yield return new WaitForSeconds (1f);
		fm.FadeIn (FadeInOutPanel, 1f);
		yield return new WaitForSeconds (.5f);
		SceneManager.LoadScene (nextroom);
	}


	private IEnumerator Fadeout(){
		fm.FadeOut (Introfade, 30f, 1f);
		yield return new WaitForSeconds (1f);
		fm.FadeOut (Introfade, .5f);
		yield return new WaitForSeconds (1f);
	}

	public IEnumerator SGCorutine(){
		//yield return new WaitForSeconds (3f);
		fm.FadeIn (FadeInOutPanel, 60f, .5f);
		yield return new WaitForSeconds (1f);
		fm.FadeIn (FadeInOutPanel, 1f);
		yield return new WaitForSeconds (.2f);
		SceneManager.LoadScene (nextroom);
	}

	private void Reset(){
		fm.CanvasGroupON (FadeInOutPanel, true);
	}

}
