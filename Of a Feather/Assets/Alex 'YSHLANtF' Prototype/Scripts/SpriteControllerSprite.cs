using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteControllerSprite : MonoBehaviour {

	//Controls all the sprites. It's like a big sprite sheet
	public GameObject playerSprite;
	public List<GameObject> classSprite = new List<GameObject>();
	public GameObject friendSprite;
	public List<Sprite> playerSpriteSheet = new List<Sprite>();
	//0 Up, 1 Left, 2 Down, 3 Right
	public List<Sprite> classSpriteSheet = new List<Sprite>();
	public List<Sprite> friendSpriteSheet = new List<Sprite> ();

	public List<GameObject> classMoveTrigger = new List<GameObject> ();

	public float initialDelaySec = 1.0f;

	//Allows a bool to prevent the class from messing with the friend's sprite change
	bool friendMove = false;

	//A public bool, to get a particle effect from the world that can be changed later.
	//This effect is only played when the TwoDGameManager says so
	public GameObject pEffectObj;
	ParticleSystem pEffectControl;

	// Use this for initialization
	void Start ()
    {
		//OBJECT NEEDS TO BE IN THE SCENE
		pEffectControl = pEffectObj.GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update ()
    {
		//Every new frame, friendMove is set to false
		friendMove = false;
	}

    static public int ConvertDirectionToSpriteIndex(MGDirectionUtils.MGDirection dir)
    {
        return MGDirectionUtils.IntFromDirection(dir);
    }

	public void EnableFriendSprite ()
	{
		SpriteRenderer temp = friendSprite.GetComponent<SpriteRenderer> ();
		temp.enabled = true;
	}

	//This has the player rapidly change instead of waiting for the delay
    public void PlayerInstantChange(int spriteIndex)
	{
		SpriteRenderer temp = playerSprite.GetComponent<SpriteRenderer> ();

		temp.sprite = playerSpriteSheet [spriteIndex];
	}

    public void PlayerChange(int spriteIndex)
	{
		StartCoroutine ("ActualChange", spriteIndex);
	}

    public void setFriendPose(MGDirectionUtils.MGDirection poseDirection)
    {
        SpriteRenderer temp = friendSprite.GetComponent<SpriteRenderer>();

        int spriteIndex = ConvertDirectionToSpriteIndex(poseDirection);
        temp.sprite = friendSpriteSheet[spriteIndex];
    }

    public void setClassPose(MGDirectionUtils.MGDirection poseDirection)
    {
        SpriteRenderer temp;

        for (int i = 0; i < classSprite.Count; i++)
        {
            temp = classSprite[i].GetComponent<SpriteRenderer>();
            temp.sprite = classSpriteSheet[ConvertDirectionToSpriteIndex(poseDirection)];
        }
    }

	//A new changing function that either randomizes the player movement, or perfectly matches.
    public void masterPlayerSpriteChange(int spriteIndex, ARROW_TYPE arrowClassification)
	{
		SpriteRenderer temp = playerSprite.GetComponent<SpriteRenderer> ();

		/*if (arrowClassification == ARROW_TYPE.FRIEND)
		{
			temp.sprite = playerSpriteSheet [listMark];
		}*/
		//If arrow_type is class, it is randomized
        // GARRAH: What does friendMove indicate? What does this code do?
        //  If friendMove is true, our player moves according to key-press
        //  If friendMove is false, the player's movement is randomized
		if (arrowClassification == ARROW_TYPE.CLASS && friendMove == false) {
			int rand = Random.Range (0, 4);

			while (rand == spriteIndex)
				rand = Random.Range (0, 4);

			temp.sprite = playerSpriteSheet [rand];
		}
		else if (arrowClassification == ARROW_TYPE.FRIEND)
		{
			temp.sprite = playerSpriteSheet [spriteIndex];
			friendMove = true;

		}
	}

    public void setPlayerSpritePose(MGDirectionUtils.MGDirection poseDirection, ARROW_TYPE arrowType)
    {
        SpriteRenderer temp = playerSprite.GetComponent<SpriteRenderer>();

        /*if (arrowClassification == ARROW_TYPE.FRIEND)
        {
            temp.sprite = playerSpriteSheet [listMark];
        }*/
        //If arrow_type is class, it is randomized
        // GARRAH: What does friendMove indicate? What does this code do?
        //  If friendMove is true, our player moves according to key-press
        //  If friendMove is false, the player's movement is randomized
        if (arrowType == ARROW_TYPE.CLASS && friendMove == false)
        {
            int rand = Random.Range(0, 4);

            while (rand == ConvertDirectionToSpriteIndex(poseDirection))
                rand = Random.Range(0, 4);

            temp.sprite = playerSpriteSheet[rand];
        }
        else if (arrowType == ARROW_TYPE.FRIEND)
        {
            temp.sprite = playerSpriteSheet[ConvertDirectionToSpriteIndex(poseDirection)];
            friendMove = true;
        }
    }

	//The same gross method in ProtoMG_DarkScript, allows the player to control their own moves.
    public void PlayerSpriteChangeMG3(int spriteIndex)
	{
		SpriteRenderer temp = playerSprite.GetComponent<SpriteRenderer> ();

		temp.sprite = playerSpriteSheet [spriteIndex];

	}

	//A void that makes pEffectControl just play
	public void ActivateParticleEffect()
	{
		pEffectControl.Play ();
	}


	//A function which grabs the list of classmates and sends it. For MG1_ClassMove
	public List<GameObject> getListGameClass()
	{

		return classSprite;

	}
}
