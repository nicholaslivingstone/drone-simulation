using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class DroneController : MonoBehaviour
{

    private Rigidbody droneRB; // Drone rigid body 

    private bool powerOn = false; 

    private FlightController flightController; 

    DroneControllerActions droneControllerActions;

    float thrust = 0f;
    float pitch = 0f;
    float roll = 0f;
    float yaw = 0f;

    Vector3 oldPos;
    public static float totalDistance = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Controller Stuff
        droneControllerActions = new DroneControllerActions();

        droneControllerActions.Up.AddDefaultBinding(Key.W); 
        droneControllerActions.Up.AddDefaultBinding(InputControlType.LeftStickUp); 

        droneControllerActions.Down.AddDefaultBinding(Key.S); 
        droneControllerActions.Down.AddDefaultBinding(InputControlType.LeftStickDown); 

        droneControllerActions.RotateLeft.AddDefaultBinding(Key.A); 
        droneControllerActions.RotateLeft.AddDefaultBinding(InputControlType.LeftStickLeft); 

        droneControllerActions.RotateRight.AddDefaultBinding(Key.D); 
        droneControllerActions.RotateRight.AddDefaultBinding(InputControlType.LeftStickRight); 

        droneControllerActions.Forward.AddDefaultBinding(Key.UpArrow); 
        droneControllerActions.Forward.AddDefaultBinding(InputControlType.RightStickUp);

        droneControllerActions.Backward.AddDefaultBinding(Key.DownArrow); 
        droneControllerActions.Backward.AddDefaultBinding(InputControlType.RightStickDown);  

        droneControllerActions.TiltLeft.AddDefaultBinding(Key.LeftArrow); 
        droneControllerActions.TiltLeft.AddDefaultBinding(InputControlType.RightStickLeft);  

        droneControllerActions.TiltRight.AddDefaultBinding(Key.RightArrow); 
        droneControllerActions.TiltRight.AddDefaultBinding(InputControlType.RightStickRight);  

        droneControllerActions.PowerBttn.AddDefaultBinding(Key.Space);
        droneControllerActions.PowerBttn.AddDefaultBinding(InputControlType.RightCommand); 


        flightController = GetComponent<FlightController>(); 
        oldPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetButtonDown("Power")){
        //     powerOn = !powerOn; 
        // }

        if(droneControllerActions.PowerBttn.WasPressed)
            powerOn = !powerOn;

        // thrust = GetInput("Throttle");
        // pitch = GetInput("Pitch");
        // roll = GetInput("Roll");
        // yaw = GetInput("Yaw");

        thrust = droneControllerActions.Thrust.Value;
        pitch = droneControllerActions.Pitch.Value;
        roll = droneControllerActions.Roll.Value;
        yaw = droneControllerActions.Yaw.Value;

        flightController.UpdateRotors(thrust, pitch, roll, yaw);
        

        // Track distance traveled
        Vector3 distanceVector = transform.position - oldPos;
        float distanceThisFrame = distanceVector.magnitude;
        totalDistance += distanceThisFrame;
        oldPos = transform.position;
    }

    public bool isPowered(){
        return powerOn; 
    }

    private float GetInput(string n){

        float temp = Input.GetAxis(n + "2");
        if(temp == 0)
            temp = Input.GetAxis(n);

        return temp; 
    }

}
