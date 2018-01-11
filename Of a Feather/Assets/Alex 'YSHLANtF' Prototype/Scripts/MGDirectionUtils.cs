using UnityEngine;

// -----------------------------------------------------------------------------
// MGDirectionUtils
//
// Description: Provides utilities for unifying direction
//  definitions/conversions.
// -----------------------------------------------------------------------------

public static class MGDirectionUtils
{
    [System.Serializable]
    public enum MGDirection
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        UNSET
    }

    static public UnityEngine.KeyCode KeyFromDirection(MGDirection dir)
    {
        UnityEngine.KeyCode ret = UnityEngine.KeyCode.UpArrow;

        switch(dir)
        {
            case MGDirection.UP:
                {
                    ret = UnityEngine.KeyCode.UpArrow;
                    break;
                }
            case MGDirection.DOWN:
                {
                    ret = UnityEngine.KeyCode.DownArrow;
                    break;
                }
            case MGDirection.LEFT:
                {
                    ret = UnityEngine.KeyCode.LeftArrow;
                    break;
                }
            case MGDirection.RIGHT:
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

    static public MGDirection DirectionFromKey(UnityEngine.KeyCode key)
    {
        MGDirection ret = MGDirection.UNSET;

        switch (key)
        {
            case UnityEngine.KeyCode.UpArrow:
                {
                    ret = MGDirection.UP;
                    break;
                }
            case UnityEngine.KeyCode.DownArrow:
                {
                    ret = MGDirection.DOWN;
                    break;
                }
            case UnityEngine.KeyCode.LeftArrow:
                {
                    ret = MGDirection.LEFT;
                    break;
                }
            case UnityEngine.KeyCode.RightArrow:
                {
                    ret = MGDirection.RIGHT;
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

    static public int IntFromDirection(MGDirection dir)
    {
        return (int)dir;
    }

    static public MGDirection DirectionFromInt(int val)
    {
        return (MGDirection)val;
    }
}
