using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    private Rigidbody droneRB; // Drone rigid body 

    private FlightController flightController; 

    float thrust = 0f;
    float pitch = 0f;
    float roll = 0f;
    float yaw = 0f;

    // Start is called before the first frame update
    void Start()
    {
        flightController = GetComponent<FlightController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float thrust = Input.GetAxis("Throttle");
        float pitch = Input.GetAxis("Pitch");
        float roll = Input.GetAxis("Roll");
        float yaw = Input.GetAxis("Yaw");

        flightController.UpdateRotors(thrust, pitch, roll, yaw);
    }

}
