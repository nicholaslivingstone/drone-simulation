using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryLED : MonoBehaviour
{

    Light lt;

    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(DroneControllerOrig.totalDistance > 10) {
            lt.color = Color.red;
        }
    }
}
