using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{

    private Rigidbody droneRB; // Drone rigid body 

    private bool powerOn = false; 

    private FlightController flightController; 

    float thrust = 0f;
    float pitch = 0f;
    float roll = 0f;
    float yaw = 0f;

    Vector3 oldPos;
    public static float totalDistance = 0;

    // Start is called before the first frame update
    void Start()
    {
        flightController = GetComponent<FlightController>(); 
        oldPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Power")){
            powerOn = !powerOn; 
        }

        thrust = Input.GetAxis("Throttle");
        pitch = Input.GetAxis("Pitch");
        roll = Input.GetAxis("Roll");
        yaw = Input.GetAxis("Yaw");

        flightController.UpdateRotors(thrust, pitch, roll, yaw);
        

        // Track distance traveled
        Vector3 distanceVector = transform.position - oldPos;
        float distanceThisFrame = distanceVector.magnitude;
        totalDistance += distanceThisFrame;
        oldPos = transform.position;
    }

    public bool GetPowerOn(){
        return powerOn; 
    }

}
