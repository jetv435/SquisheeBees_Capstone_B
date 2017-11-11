using UnityEngine;

// -----------------------------------------------------------------------------
// AOAFMinigameManager
//
// Description: Abstract base component script. Adds specific functionality for
//  the dance/rhythm minigames in Of a Feather
// -----------------------------------------------------------------------------

abstract public class AOAFMinigameManager : AScoredGameManager
{
    public GameObject mainArrowObject;                          // FORMERLY "arrowObj"
    public int maxScoreNeededInTotal = 10;

    // Sprite controller
    private GameObject _spriteControllerOBJECT;                 // FORMERLY "callSpriteBoss"
    private SpriteControllerSprite _spriteControllerSCRIPT;     // FORMERLY "callSprScr"

    // Scene changer
    private GameObject _sceneChangeManagerOBJECT;               // FORMERLY "sceneBoss"
    private GameBossCode _sceneChangeManagerSCRIPT;             // FORMERLY "sceneControl"

    // Sound controller
    private GameObject _soundControllerOBJECT;                  // FORMERLY "soundObj"
    private SoundScript _soundControllerSCRIPT;                 // FORMERLY "soundScr"

    // Main arrow script
    private ArrowTurnScript _mainArrowScript;                   // FORMERLY "arrowScr"

    void Start()
    {
        this._spriteControllerOBJECT = GameObject.FindGameObjectWithTag("SpriteController");
        this._spriteControllerSCRIPT = this._spriteControllerOBJECT.GetComponent<SpriteControllerSprite>();

        this._sceneChangeManagerOBJECT = GameObject.FindGameObjectWithTag("GameController");
        this._sceneChangeManagerSCRIPT = this._sceneChangeManagerOBJECT.GetComponent<GameBossCode>();

        this._soundControllerOBJECT = GameObject.FindGameObjectWithTag("SoundControllerTag");
        this._soundControllerSCRIPT = this._soundControllerOBJECT.GetComponent<SoundScript>();

        this._mainArrowScript = this.mainArrowObject.GetComponent<ArrowTurnScript>();
    }

    protected override void OnScoreIncrease()
    {
        this._mainArrowScript.disableArrow();
    }

    public void SetMainArrowDirection(MGArrowUtils.MGArrowDirection dir)
    {
        // TODO: refactor sprite manager to take MGArrowDirection, and refactor
        //  the following line to take "dir":

        //callSprScr.ClassChange (classArrNumPrev);

        this.GetSoundController().ResumePlay();
    }

    // Returns sprite controller
    protected SpriteControllerSprite GetSpriteController()
    {
        return this._spriteControllerSCRIPT;
    }

    // Returns scene changer
    protected GameBossCode GetSceneChangeManager()
    {
        return this._sceneChangeManagerSCRIPT;
    }

    // Returns sound controller
    protected SoundScript GetSoundController()
    {
        return this._soundControllerSCRIPT;
    }
}
