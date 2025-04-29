using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    bool AICam = false;
    GameObject AICamObj = null;

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (AICam == false)
            {
                if (Physics.Raycast(ray, out var hit, 10000.0f))
                {
                    if (hit.transform.CompareTag("AI"))
                    {
                        AICamObj = hit.transform.GetChild(1).gameObject;
                        AICamObj.SetActive(true);
                        AICam = true;
                    }
                }
            }
            else 
            {
                AICamObj.SetActive(false);
                AICamObj = null;
                AICam = false;
            }
        }
    }
}
