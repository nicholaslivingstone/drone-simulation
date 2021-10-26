using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerBatteryLED : MonoBehaviour
{

    public static float timeRemaining = 10;
    public static bool remoteOn = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // if(DroneController.totalDistance > 10) {
        //     GetComponent<Image>().color = Color.red;
        // }

        if (timeRemaining > 0) {
            timeRemaining -= Time.deltaTime;
        }
        else {
            remoteOn = false;
            timeRemaining = 0;
            GetComponent<Image>().color = Color.red;
        }
    }
}
