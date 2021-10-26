using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMU : MonoBehaviour
{
    private Vector3 acceleration;
    private Vector3 distancemoved=Vector3.zero;
    private Vector3 lastdistancemoved=Vector3.zero;
    private Vector3 last;

    void Start() {
        last = transform.position;
    }
    void Update(){   
        distancemoved = (transform.position - last) * Time.deltaTime ;
        acceleration = distancemoved - lastdistancemoved;
        lastdistancemoved = distancemoved;
        last = transform.position;
    }

    public Vector3 GetAcceleration(){
        return acceleration;
    }
}
