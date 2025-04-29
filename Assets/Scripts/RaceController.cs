using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;

public class RaceController : MonoBehaviour
{
    public delegate void OnRaceStart();
    public static event OnRaceStart onRaceStart;
    public void StartRace()
    {
        onRaceStart();
    }
}
