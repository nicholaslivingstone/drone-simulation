using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightController : MonoBehaviour
{
    public float speed = 10f; 
    public float thrustScale = 10f; 

    public rotor rotorFR; // Front Left rotor
    public rotor rotorFL; // Front Right rotor
    public rotor rotorBR; // Back Right rotor
    public rotor rotorBL; // Back Left rotor

    private rotor[] rotors;

    public bool enablePitch = false; 

    public bool enableRoll = false; 

    public bool realPhysics = false; 

    private Rigidbody droneRB; 
    
    private IMU imu; 

    private Gyro gyro; 


    void Start()
    {
        rotors = new rotor[]{rotorBL, rotorBR, rotorFL, rotorFR};
        imu = GetComponent<IMU>(); 
    }

    public void UpdateRotors(float thrustInput, float pitchInput, float rollInput, float yawInput){
        float upwardThrust,
                powerFR,
                powerFL,
                powerBR,
                powerBL;

        if(thrustInput == 0)
            upwardThrust =  9.8f / 4f;
        else{
            thrustInput *= speed;
            upwardThrust = (-imu.GetAcceleration().y + 9.8f + thrustInput) / 4f;
        }

        powerFR = upwardThrust;
        powerFL = upwardThrust; 
        powerBL = upwardThrust;
        powerBR = upwardThrust;

        if(pitchInput != 0 && enablePitch){
            pitchInput *= 0.25f;

            powerFR -= pitchInput; 
            powerFL -= pitchInput; 
            powerBR += pitchInput; 
            powerBL += pitchInput;
        }

        if(rollInput != 0 && enableRoll){
            rollInput *= 0.25f;

            powerFR += rollInput; 
            powerFL -= rollInput; 
            powerBR += rollInput; 
            powerBL -= rollInput;
        }

        rotorBL.setPower(powerBL); 
        rotorBR.setPower(powerBR); 
        rotorFL.setPower(powerFL); 
        rotorFR.setPower(powerFR); 

        

        transform.Rotate(new Vector3(0, yawInput, 0));

        
    }

}
