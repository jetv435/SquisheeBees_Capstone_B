using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameBossCode : MonoBehaviour {

	private MainMenuManager MM;

	void Start()
    {
		MM = GameObject.FindGameObjectWithTag ("MManager").GetComponent<MainMenuManager> ();
	}
	// Update is called once per frame
	void Update ()
    {
		DebugControls_SceneShift ();
	
	}

	void DebugControls_SceneShift()
	{
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			SceneManager.LoadScene ("Basement0");
		}
		else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			SceneManager.LoadScene ("Room_Minigame1");
		}
		else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			SceneManager.LoadScene ("Basement1");
		}
		else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			SceneManager.LoadScene ("Room_Minigame2");
		}
		else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			SceneManager.LoadScene ("Basement2");
		}
		else if (Input.GetKeyDown (KeyCode.Alpha6)) {
			SceneManager.LoadScene ("Room_Minigame3");
		}
	}

	public void GoToBasement(int RoomNum)
	{
		StartCoroutine (MM.Transition ());
	}
}
