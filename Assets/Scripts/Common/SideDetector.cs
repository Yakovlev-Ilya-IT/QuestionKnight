using UnityEngine;

public static class SideDetector 
{
    private const float tanPiDividedSix = 0.00913877f;

    public static AnswerLocationSide GetLocation(Vector3 point)
    {
        if (point.y > -point.x * tanPiDividedSix && point.x > 0)
            return AnswerLocationSide.right;
        if (point.y > point.x * tanPiDividedSix && point.x < 0)
            return AnswerLocationSide.left;
        if (point.y < point.x * tanPiDividedSix && point.y < -point.x * tanPiDividedSix)
            return AnswerLocationSide.bottom;

        Debug.LogError($"Error point is {point}");
        return AnswerLocationSide.left;
    }
}
