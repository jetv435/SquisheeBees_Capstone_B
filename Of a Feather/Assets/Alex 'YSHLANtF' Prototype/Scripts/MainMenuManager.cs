using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	private FadeManager fm;
	public CanvasGroup FadeInOutPanel;
	public CanvasGroup Introfade;

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

	void OnTriggerEnter(Collider other){
		StartCoroutine (SGCorutine());

	}


	public IEnumerator Transition(){
		fm.FadeIn (FadeInOutPanel, 1f);
		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene ("Room_3");
	}

	private IEnumerator Fadeout(){
		fm.FadeOut (Introfade, 1f);
		yield return new WaitForSeconds (5f);
	}

	private IEnumerator SGCorutine(){
		fm.FadeIn (FadeInOutPanel, 1f);
		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene ("Room_Minigame1");
	}

	private void Reset(){
		fm.CanvasGroupON (FadeInOutPanel, true);
	}

}
