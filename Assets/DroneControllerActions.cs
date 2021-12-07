using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class DroneControllerActions : PlayerActionSet
{
    public PlayerAction Up;
    public PlayerAction Down;
    public PlayerAction RotateRight;
    public PlayerAction RotateLeft;
    public PlayerAction TiltRight;
    public PlayerAction TiltLeft;
    public PlayerAction Forward;
    public PlayerAction Backward;
    public PlayerOneAxisAction Yaw;
    public PlayerOneAxisAction Thrust;
    public PlayerOneAxisAction Roll; 

    public PlayerOneAxisAction Pitch;

    public DroneControllerActions(){
        Up = CreatePlayerAction("Move Up");
        Down = CreatePlayerAction("Move Down");
        RotateLeft = CreatePlayerAction("Rotate Drone Left");
        RotateRight = CreatePlayerAction("Rotate Drone Right");
        TiltLeft = CreatePlayerAction("Tilt Drone Left");
        TiltRight = CreatePlayerAction("Tilt Drone Right");
        Forward = CreatePlayerAction("Move Drone Forward");
        Backward = CreatePlayerAction("Move Drone Backward");

        Yaw = CreateOneAxisPlayerAction(RotateLeft, RotateRight);
        Thrust = CreateOneAxisPlayerAction(Down, Up);
        Roll = CreateOneAxisPlayerAction(TiltLeft, TiltRight);
        Pitch = CreateOneAxisPlayerAction(Backward, Forward);
    }
}
