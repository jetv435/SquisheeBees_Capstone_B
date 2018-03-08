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
			SceneManager.LoadScene ("Basement1");
		}
		else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			SceneManager.LoadScene ("Room_Minigame1");
		}
		else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			SceneManager.LoadScene ("Basement2");
		}
		else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			SceneManager.LoadScene ("Basement3");
		}
		else if (Input.GetKeyDown (KeyCode.Alpha6)) {
			SceneManager.LoadScene ("Room_Minigame2");
		}
		else if (Input.GetKeyDown (KeyCode.Alpha7)) {
			SceneManager.LoadScene ("Basement4");
		}
		else if (Input.GetKeyDown (KeyCode.Alpha8)) {
			SceneManager.LoadScene ("Room_Minigame3");
		}
		else if (Input.GetKeyDown (KeyCode.Alpha9)) {
			SceneManager.LoadScene ("Basement5");
		}
		else if (Input.GetKeyDown (KeyCode.Alpha0)) {
			SceneManager.LoadScene ("Room_Minigame4");
		}
        else if(Input.GetKeyDown(KeyCode.O))
        {
            // save basement
            BasementSaveSystem.SaveBasement("default_save", BasementSaveSystem.BasementSerialID.BASEMENT_BackToNormal);
        }
        else if(Input.GetKeyDown(KeyCode.P))
        {
            // load basement
            BasementSaveSystem.Code saveRet = BasementSaveSystem.LoadBasement("default_save");

            // check for any error return codes
            if (saveRet != BasementSaveSystem.Code.SUCCESS)
            {
                switch (saveRet)
                {
                    case BasementSaveSystem.Code.SAVE_FILE_NOT_FOUND:
                        {
                            Debug.LogError("Save file not found in LoadBasement()");
                        } break;
                    case BasementSaveSystem.Code.VERSION_MISMATCH:
                        {
                            Debug.LogError("Save file version mismatch in LoadBasement()");
                        } break;
                    case BasementSaveSystem.Code.INVALID_FILE_DATA:
                        {
                            Debug.LogError("Invalid save file data in LoadBasement()");
                        } break;
                    default:
                        {
                            Debug.LogError("Unexpected error returned from LoadBasement()");
                        } break;
                }
            }

        }
	}

	public void GoToBasement(int RoomNum)
	{
		StartCoroutine (MM.Transition ());
	}


}
