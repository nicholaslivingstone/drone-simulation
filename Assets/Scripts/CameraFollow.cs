using UnityEngine;
using InControl;

public class CameraFollow : MonoBehaviour {

	public Transform target;

    public float RotationSpeed = 1f; 

	public float smoothSpeed = 0.125f;
	public Vector3 offset;

    private float rotation = 0f; 

    DroneControllerActions droneControllerActions; 

    private void Start() {
        droneControllerActions = new DroneControllerActions();

        droneControllerActions.CamRight.AddDefaultBinding(Key.E);
        droneControllerActions.CamRight.AddDefaultBinding(InputControlType.RightBumper);

        droneControllerActions.CamLeft.AddDefaultBinding(Key.Q);
        droneControllerActions.CamLeft.AddDefaultBinding(InputControlType.LeftBumper); 
    }

    private void Update() {
        rotation += droneControllerActions.RotateCam.Value * RotationSpeed;

        if(rotation > 360 || rotation < -360){
            rotation = 0f; 
        }
    }

	void FixedUpdate ()
	{
		transform.position = target.position + offset; //smoothedPosition;
        transform.RotateAround(target.position, Vector3.up, rotation);

		transform.LookAt(target);
        
	}

}