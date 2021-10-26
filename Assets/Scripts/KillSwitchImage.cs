using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillSwitchImage : MonoBehaviour
{

    public static bool isOn = true;

    public DroneController drone;

    // Update is called once per frame
    void Update()
    {
        if (drone.GetPowerOn()) {
            GetComponent<Image>().color = Color.green;
        }
        else {
            GetComponent<Image>().color = Color.red;
        }
    }
}
