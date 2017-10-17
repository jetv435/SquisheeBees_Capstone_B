using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameBossCode : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Keypad1)) {
			SceneManager.LoadScene ("Room_1");
		}
		if (Input.GetKeyDown (KeyCode.Keypad2)) {
			SceneManager.LoadScene ("Room_1_Mid");
		}
		if (Input.GetKeyDown (KeyCode.Keypad3)) {
			SceneManager.LoadScene ("Room_2");
		}
		if (Input.GetKeyDown (KeyCode.Keypad4)) {
			SceneManager.LoadScene ("Room_2_Mid");
		}
		if (Input.GetKeyDown (KeyCode.Keypad5)) {
			SceneManager.LoadScene ("Room_3");
		}
	
	}
}
