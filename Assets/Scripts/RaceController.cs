using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;

public class RaceController : MonoBehaviour
{
    public delegate void OnRaceStart();
    public static event OnRaceStart onRaceStart;

    public delegate void OnRaceEnd();
    public static event OnRaceEnd onRaceEnd;
    public void StartRace()
    {
        onRaceStart();
    }

    public void EndRace()
    {
        onRaceEnd();
    }
}
