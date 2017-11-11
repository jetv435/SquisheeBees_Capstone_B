using UnityEngine;

// -----------------------------------------------------------------------------
// MGArrowUtils
//
// Description: Provides utilities for unifying arrow definitions/conversions
//  for the dance minigames.
// -----------------------------------------------------------------------------

public static class MGArrowUtils
{
    [System.Serializable]
    public enum MGArrowDirection
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    static public UnityEngine.KeyCode KeyFromDirection(MGArrowDirection dir)
    {
        UnityEngine.KeyCode ret = UnityEngine.KeyCode.UpArrow;

        switch(dir)
        {
            case MGArrowDirection.UP:
                {
                    ret = UnityEngine.KeyCode.UpArrow;
                    break;
                }
            case MGArrowDirection.DOWN:
                {
                    ret = UnityEngine.KeyCode.DownArrow;
                    break;
                }
            case MGArrowDirection.LEFT:
                {
                    ret = UnityEngine.KeyCode.LeftArrow;
                    break;
                }
            case MGArrowDirection.RIGHT:
                {
                    ret = UnityEngine.KeyCode.RightArrow;
                    break;
                }
            default:
                {
                    Debug.LogError("Unexpected value for dir in MGArrowUtils.KeyFromDirection");
                    break;
                }
        }
        return ret;
    }

    static public MGArrowDirection DirectionFromKey(UnityEngine.KeyCode key)
    {
        MGArrowDirection ret = MGArrowDirection.UP;

        switch (key)
        {
            case UnityEngine.KeyCode.UpArrow:
                {
                    ret = MGArrowDirection.UP;
                    break;
                }
            case UnityEngine.KeyCode.DownArrow:
                {
                    ret = MGArrowDirection.DOWN;
                    break;
                }
            case UnityEngine.KeyCode.LeftArrow:
                {
                    ret = MGArrowDirection.LEFT;
                    break;
                }
            case UnityEngine.KeyCode.RightArrow:
                {
                    ret = MGArrowDirection.RIGHT;
                    break;
                }
            default:
                {
                    Debug.LogError("Unexpected value for key in MGArrowUtils.DirectionFromKey");
                    break;
                }
        }
        return ret;
    }
}
