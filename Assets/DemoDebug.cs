using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class DemoDebug : MonoBehaviour
{

    droneMovementController drone;
    public GameObject targetPrefab; 
    public GameObject target;

    DroneControllerActions droneControllerActions;

    // Start is called before the first frame update
    void Start()
    {
        drone = GetComponent<droneMovementController>();
        Vector3 startPos = transform.position + transform.forward;
        target = Instantiate(targetPrefab, startPos, Quaternion.identity); 

        drone.target = target.transform;

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
        
    }
}
