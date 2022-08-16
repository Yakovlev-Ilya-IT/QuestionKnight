using UnityEngine;

public static class SideDetector 
{
    private const float tanPiDividedSix = 0.00913877f;

    public static AnswerLocationSide GetLocation(Vector3 point)
    {
        if (CheckRightSide(point))
            return AnswerLocationSide.Right;
        if (CheckLeftSide(point))
            return AnswerLocationSide.Left;
        if (CheckBottomSide(point))
            return AnswerLocationSide.Bottom;

        Debug.LogError($"Error point is {point}");
        return AnswerLocationSide.Left;
    }

    private static bool CheckLeftSide(Vector3 point) => point.y >= point.x * tanPiDividedSix && point.x <= 0;

    private static bool CheckRightSide(Vector3 point) => point.y >= -point.x * tanPiDividedSix && point.x >= 0;

    private static bool CheckBottomSide(Vector3 point) => point.y <= point.x * tanPiDividedSix && point.y <= -point.x * tanPiDividedSix;
}
