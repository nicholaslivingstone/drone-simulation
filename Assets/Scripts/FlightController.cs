using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightController : MonoBehaviour
{
    public float thrustScale = 10f; 
    public float power = 5f; 

    public rotor rotorFR; // Front Left rotor
    public rotor rotorFL; // Front Right rotor
    public rotor rotorBR; // Back Right rotor
    public rotor rotorBL; // Back Left rotor
    
    private rotor[] rotors; 


    void Start()
    {
        rotors = new rotor[] {rotorFR, rotorFL, rotorBL, rotorBR};
    }

    public void UpdateControls(float thrustInput, float pitchInput, float rollInput, float yawInput){
        
        UpdateThrust(thrustInput);

    }

    void UpdateThrust(float thrust){
        

        for(int i = 0; i < rotors.Length; i++){
            rotors[i].setPower(thrust * thrustScale);
        }
    }
}
