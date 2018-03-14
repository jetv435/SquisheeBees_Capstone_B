using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	//MainMenuManager MM;


	// Use this for initialization
	void Start () {
		//MM = GameObject.FindGameObjectWithTag ("MManager").GetComponent<MainMenuManager> ();

		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.F1)) {
			Quit ();
		}
		
	}

	public void Instructions(){

		SceneManager.LoadScene ("Instructions");

	}

	public void goPlay()
	{

		SceneManager.LoadScene ("Basement0");
		//StartCoroutine (MM.SGCorutine ());
	}

	public void MainMenu()
	{
		SceneManager.LoadScene ("MainMenu");

	}

	public void Credits()
	{
		SceneManager.LoadScene ("CreditsRoom");
	}

	public void Quit()
	{
		Application.Quit ();
	}
}
