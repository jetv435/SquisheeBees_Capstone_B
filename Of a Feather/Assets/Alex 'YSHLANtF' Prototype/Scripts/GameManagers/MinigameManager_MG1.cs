using UnityEngine;

// -----------------------------------------------------------------------------
// MinigameManager_MG1
//
// Description: Minigame 1 Manager. Realizes the specific features/behavior of
//  the first minigame.
//
// TODO: TwoDGameManager may be "handling" too many things that aren't its job,
//  and certain behavior in this new code don't provide direct analoges to
//  existing implementation. Other systems/scripts will need to be refactored.
//
//  For instance, perhaps score increases should not be direct triggers of
//  sprite changes. Also, the "dual" purposes of the score may be more slap-dash
//  than we'd want. The "friendEntranceSoundSource" should probably also be
//  referenced and messaged through the pre-existing sound controller in the
//  AOAFMinigameManager script, rather than through this script.
// -----------------------------------------------------------------------------

public class MinigameManager_MG1 : AOAFMinigameManager
{
    public int maxScoreFriend = 3;
    public AudioSource friendEntranceSoundSource;           // FORMERLY "friendenter"
    public GameObject friendArrowObject;                    // FORMERLY "arrowObjFriend"
   
    private bool _bFriendSpriteOn = false;                  // FORMERLY "friendSprOn"
    private bool _bFriendArrowOn = false;                   // FORMERLY "ArrowOn"
    private ArrowTurnScript _friendArrowScript;             // FORMERLY "arrowScrFrd"
    private int _friendCurrentSpriteFrame = -1;             // FORMERLY "friendMark"

	// Use this for initialization
	void Start ()
    {
        _friendArrowScript = friendArrowObject.GetComponent<ArrowTurnScript>();
	}

    protected override void OnScoreIncrease()
    {
        // call AOAFMinigameManager's OnScoreIncrease() implementation
        base.OnScoreIncrease();

        // activate friend
        if (this.GetScore() >= this.maxScoreFriend && this._bFriendSpriteOn == false)
        {
            this.GetSpriteController().TurnOnFriendSpr();
            this._bFriendArrowOn = true;
            this._bFriendSpriteOn = true;
            this.friendEntranceSoundSource.Play();
        }

        // Alex Comment: Need to change it later, once we get animations
        if (this.GetScore() >= this.maxScoreNeededInTotal)
        {
            this.GetSceneChangeManager().GoToBasement(1);
        }

        this.GetSpriteController().ActivatePEffect();
        this._friendArrowScript.disableArrow();
    }

    // Check if the friend is active
    public bool IsFriendActive()
    {
        return this._bFriendSpriteOn;
    }

    // Sets the current frame of the friend sprite
    public void SetFriendFrameIndex(int frameIndex)
    {
        this._friendCurrentSpriteFrame = frameIndex;
        this.GetSpriteController().FriendChange(this._friendCurrentSpriteFrame);
    }

    // Gets the current frame of the friend sprite
    public int GetFriendFrameIndex()
    {
        return this._friendCurrentSpriteFrame;
    }

    public void SetFriendArrowDirection(MGArrowUtils.MGArrowDirection dir)
    {
        // TODO: refactor sprite manager to take MGArrowDirection, and refactor
        //  the following line to take "dir":

        //callSprScr.FriendChange(friendArrNumPrev);

        this.GetSoundController().ResumePlay();
    }
}
