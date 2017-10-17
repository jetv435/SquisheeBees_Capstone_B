using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteControllerSprite : MonoBehaviour {

	public GameObject playerSprite;
	public GameObject classSprite;
	public GameObject friendSprite;
	public List<Sprite> playerSpriteSheet = new List<Sprite>();
	//0 Up, 1 Left, 2 Down, 3 Right
	public List<Sprite> classSpriteSheet = new List<Sprite>();
	public List<Sprite> friendSpriteSheet = new List<Sprite> ();

	public List<GameObject> classMoveTrigger = new List<GameObject> ();

	public float initialDelaySec = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TurnOnFriendSpr ()
	{
		SpriteRenderer temp = friendSprite.GetComponent<SpriteRenderer> ();
		temp.enabled = true;
	}

	public void PlayerChange(int listMark)
	{
		

		StartCoroutine ("ActualChange", listMark);
	}

	IEnumerator ActualChange (int listMark)
	{
		yield return new WaitForSeconds (initialDelaySec);

		SpriteRenderer temp = playerSprite.GetComponent<SpriteRenderer> ();


		temp.sprite = playerSpriteSheet [listMark];

		temp = friendSprite.GetComponent<SpriteRenderer> ();
		temp.sprite = friendSpriteSheet [listMark];

	}

	public void ClassChange(int listMark)
	{
		SpriteRenderer temp = classSprite.GetComponent<SpriteRenderer> ();

		temp.sprite = classSpriteSheet [listMark];
	}
}
