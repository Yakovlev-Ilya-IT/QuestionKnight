using System;
using UnityEngine;

public class QuizEventHandler : MonoBehaviour
{
    public static event Action<Vector3> CristallSwipeEnded;
    public static event Action CristallSwipeBegun;

    public static void SendCristallSwipeEnded(Vector3 direction)
    {
       CristallSwipeEnded?.Invoke(direction);
    }

    public static void SendCristallSwipeBegun()
    {
        CristallSwipeBegun?.Invoke();
    }
}
