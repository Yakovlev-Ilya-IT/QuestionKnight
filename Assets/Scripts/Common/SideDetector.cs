using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SideDetector 
{
    public static AnswerLocationSide GetLocation(Vector3 point)
    {
        if (point.x > point.y && point.x > -point.y)
            return AnswerLocationSide.right;
        if (-point.x > point.y && -point.x > -point.y)
            return AnswerLocationSide.left;
        if (-point.y > -point.x && -point.y > point.x)
            return AnswerLocationSide.bottom;
        else
            return AnswerLocationSide.top;


    }
}
