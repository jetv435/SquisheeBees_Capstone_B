using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTrigger : MonoBehaviour {


	public Storylines story;

	public void triggerstory(){

		FindObjectOfType<DialogManager> ().startstory (story);
	}


}
