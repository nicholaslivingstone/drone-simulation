using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightController : MonoBehaviour
{
    public float speed = 10f; 
    public float thrustScale = 10f; 

    public float hoverAdjust = 1f; 

    public float pitchAdjustment = 1f; 

    private rotor rotorFR; // Front Left rotor
    private rotor rotorFL; // Front Right rotor
    private rotor rotorBR; // Back Right rotor
    private rotor rotorBL; // Back Left rotor

    private rotor[] rotors;

    public bool enablePitch = false; 

    public bool enableRoll = false; 

    public bool realPhysics = false; 

    private Rigidbody droneRB; 

    private DroneController drone; 
    
    private IMU imu; 

    private Gyro gyro; 


    void Start()
    {
        rotorBL = transform.Find("rotorBL").GetComponent<rotor>();
        rotorBR = transform.Find("rotorBR").GetComponent<rotor>();
        rotorFL = transform.Find("rotorFL").GetComponent<rotor>();
        rotorFR = transform.Find("rotorFR").GetComponent<rotor>();

        rotors = new rotor[]{rotorBL, rotorBR, rotorFL, rotorFR};
        imu = GetComponent<IMU>(); 
        drone = GetComponent<DroneController>();
    }

    public void UpdateRotors(float thrustInput, float pitchInput, float rollInput, float yawInput){
        float upwardThrust,
                powerFR,
                powerFL,
                powerBR,
                powerBL;

        if(!drone.isPowered()){
            foreach(rotor r in rotors){
                r.setPower(0);
            }
            return; 
        }

        if(thrustInput == 0 && drone)
            upwardThrust =  (-imu.GetVelocity().y * hoverAdjust + 9.8f )/ 4f;
        else{
            thrustInput *= speed;
            //upwardThrust = (-imu.GetAcceleration().y + 9.8f + thrustInput) / 4f;
            upwardThrust = (9.8f + thrustInput) / 4f;
        }

        powerFR = upwardThrust;
        powerFL = upwardThrust; 
        powerBL = upwardThrust;
        powerBR = upwardThrust;

        if(pitchInput != 0 && enablePitch){
            pitchInput *= pitchAdjustment;

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
