using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControlMG2Script : MonoBehaviour {

	//There are two lights on the PlayerCharacter
	public List<GameObject> playerCharacterLightList = new List<GameObject> ();
	//Two lights for the missing friend
	public List<GameObject> missingFriendLightList = new List<GameObject> ();
	//The main area light that lights up the main board
	public GameObject areaLightObject;
	//Grabs the background object to make it even darker
	public GameObject backgroundObject;
	SpriteRenderer backgroundSpriteRenderer;

	// Use this for initialization
	void Start () {

		backgroundSpriteRenderer = backgroundObject.GetComponent<SpriteRenderer> ();
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void UpdateLightsAndBackground()
	{
		Light areaLightLight = areaLightObject.GetComponent<Light> ();
		Light playerLight;

		for(int i = 0; i  < playerCharacterLightList.Count; i++)
		{
			playerLight = playerCharacterLightList [i].GetComponent<Light>();

			if (playerLight.intensity < 1.0f) {
				playerLight.intensity += 0.1f;
			}
		}

		for (int i = 0; i < missingFriendLightList.Count; i++) {
			Light friendLight = missingFriendLightList [i].GetComponent<Light>();

			if (friendLight.intensity > 0) {
				friendLight.intensity -= 0.2f;
			}
		}

		if(areaLightLight.intensity > 0)
			areaLightLight.intensity -= 0.5f;
		else
		{
			Color newColor = backgroundSpriteRenderer.color;
			newColor = new Color(newColor.r - 0.07f, newColor.g - 0.07f, newColor.b -0.07f);

			//if (newColor.r < 0.9f) {
				
			//}

			if(newColor.r > 0.2f)
				backgroundSpriteRenderer.color = newColor;


		}
	}
}
