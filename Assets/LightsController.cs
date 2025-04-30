using System.ComponentModel;
using UnityEngine;

public class LightsController : MonoBehaviour
{
    public RaceController raceController;    

    public void StartRace()
    {
        raceController.StartRace();
    }
}
