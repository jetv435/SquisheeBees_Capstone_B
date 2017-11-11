using UnityEngine;

// -----------------------------------------------------------------------------
// AScoredGameManager
//
// Description: Abstract base component script. Provides simple scored game
//  functionality and extensibility methods.
// -----------------------------------------------------------------------------

abstract public class AScoredGameManager : MonoBehaviour
{
    private int _score = 0; // FORMERLY "Score"

    // Can be overridden by derived class implementation
    protected virtual void OnScoreIncrease() {}
    protected virtual void OnScoreReset() {}

    // Increases score
    public void IncreaseScore(int scoreIncrease)
    {
        this._score += scoreIncrease;
        this.OnScoreIncrease();
    }

    // Resets score
    public void ResetScore()
    {
        this._score = 0;
        this.OnScoreReset();
    }

    public int GetScore()
    {
        return this._score;
    }
}
