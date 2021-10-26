using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightController : MonoBehaviour
{
    public float thrustScale = 10f; 

    public rotor rotorFR; // Front Left rotor
    public rotor rotorFL; // Front Right rotor
    public rotor rotorBR; // Back Right rotor
    public rotor rotorBL; // Back Left rotor
    
    private rotor[] rotors; 
    
    private IMU imu; 


    void Start()
    {
        rotors = new rotor[] {rotorFR, rotorFL, rotorBL, rotorBR};
        imu = GetComponent<IMU>(); 
    }

    public void UpdateRotors(float thrustInput, float pitchInput, float rollInput, float yawInput){
        float upwardThrust,
                yAcc = 0; 

        if(thrustInput == 0)
            upwardThrust =  9.8f / 4f;
        else{
            thrustInput *= thrustScale;

            if(Mathf.Abs(imu.GetAcceleration().y) > 0.001f)
                yAcc = imu.GetAcceleration().y;
            
            upwardThrust = (-yAcc + 9.8f + thrustInput) / 4f;
        }

        UpdateThrust(upwardThrust);
    }

    void UpdateThrust(float thrust){
        

        for(int i = 0; i < rotors.Length; i++){
            rotors[i].setPower(thrust);
        }
    }
}
