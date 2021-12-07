using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl; 

public class CustomDroneInput : MonoBehaviour
{

    DroneControllerActions droneControllerActions;

    DroneMovement droneMovement;

    // Start is called before the first frame update
    void Start()
    {
        droneMovement = GetComponent<DroneMovement>();

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
    }

    // Update is called once per frame
    void Update()
    {
        droneMovement.customFeed_backward = droneControllerActions.Backward.Value;
        droneMovement.customFeed_forward = droneControllerActions.Forward.Value;
        droneMovement.customFeed_leftward = droneControllerActions.TiltLeft.Value;
        droneMovement.customFeed_rightward = droneControllerActions.TiltRight.Value;
        droneMovement.customFeed_rotateLeft = droneControllerActions.RotateLeft.Value; 
        droneMovement.customFeed_rotateRight = droneControllerActions.RotateRight.Value;
        droneMovement.customFeed_upward = droneControllerActions.Up.Value;
        droneMovement.customFeed_downward = droneControllerActions.Down.Value;
    }
}
