using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	private FadeManager fm;
	public CanvasGroup FadeInOutPanel;
	public CanvasGroup Introfade;
	//public int previous;
	public int nextroom;
	public AudioSource ambient;
	public AudioSource ambient1;

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
		fm.FadeIn (FadeInOutPanel, 60, 1f);
		ambient.Stop ();
		ambient1.mute = true;
		yield return new WaitForSeconds (5f);
		fm.FadeIn (FadeInOutPanel, 120f, 1f);
		yield return new WaitForSeconds (5f);
		SceneManager.LoadScene (nextroom);
	}


	private IEnumerator Fadeout(){
		fm.FadeOut (Introfade, 30f, 1f);
		ambient.PlayDelayed (4.75f);
		ambient1.mute = true;
		yield return new WaitForSeconds (5f);
		fm.FadeOut (Introfade, 1f);
		yield return new WaitForSeconds (1f);
		ambient1.mute = false;
	}

	public IEnumerator SGCorutine(){
		//yield return new WaitForSeconds (3f);
		fm.FadeIn (FadeInOutPanel, 60f, 1f);
		yield return new WaitForSeconds (1f);
		ambient.Stop ();
		fm.FadeIn (FadeInOutPanel, 120f, 1f);
		yield return new WaitForSeconds (5f);
		SceneManager.LoadScene (nextroom);
	}

	private void Reset(){
		fm.CanvasGroupON (FadeInOutPanel, true);
	}

}
