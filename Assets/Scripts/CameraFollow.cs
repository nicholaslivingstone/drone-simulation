using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;

    public float RotationSpeed = 1f; 

	public float smoothSpeed = 0.125f;
	public Vector3 offset;

    private float rotation = 0f; 

    private void Update() {
        rotation += Input.GetAxis("Camera Rotate") * RotationSpeed;

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