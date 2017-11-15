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

	//void OnTriggerEnter(Collider other){
		//StartCoroutine (SGCorutine());

	//}


	public IEnumerator Transition(){
		fm.FadeIn (FadeInOutPanel, 60, .5f);
		yield return new WaitForSeconds (1f);
		fm.FadeIn (FadeInOutPanel, 1f);
		yield return new WaitForSeconds (1.5f);
		SceneManager.LoadScene ("Room_3");
	}

	private IEnumerator Fadeout(){
		fm.FadeOut (Introfade, 30f, 1f);
		yield return new WaitForSeconds (1f);
		fm.FadeOut (Introfade, .5f);
		yield return new WaitForSeconds (1.5f);
	}

	public IEnumerator SGCorutine(){
		//yield return new WaitForSeconds (3f);
		fm.FadeIn (FadeInOutPanel, 60f, .5f);
		yield return new WaitForSeconds (1f);
		fm.FadeIn (FadeInOutPanel, 1f);
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene ("Room_Minigame1");
	}

	private void Reset(){
		fm.CanvasGroupON (FadeInOutPanel, true);
	}

}
