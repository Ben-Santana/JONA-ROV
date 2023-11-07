using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{

    Rigidbody rig;
    public float speed = 60;
    private float accel;

    public bool checkWater = false;
    private bool inWater = true;
    private bool pitchRoll = false; // true = yaw |  false = pitch
    public Transform top_forwl;
    public Transform top_forwr;
    public Transform top_backl;
    public Transform top_backr;


    public Transform bottom_forwl;
    public Transform bottom_forwr;
    public Transform bottom_backl;
    public Transform bottom_backr;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        accel = speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        inWater = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inWater = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab)) pitchRoll = !pitchRoll;


        if (inWater || !checkWater)
        {
            if (pitchRoll)
            {

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    accel = -speed;
                }
                else accel = speed;

                if (Input.GetKey(KeyCode.Space)) thrustAll(accel);
                if (Input.GetKey(KeyCode.W)) forwardPitch(accel / 4);
                if (Input.GetKey(KeyCode.S)) backPitch(accel / 4);
                if (Input.GetKey(KeyCode.A)) leftRoll(accel / 4);
                if (Input.GetKey(KeyCode.D)) rightRoll(accel / 4);

            }
            else
            {

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    accel = -speed;
                }
                else accel = speed;


                if (Input.GetKey(KeyCode.Space)) thrustAll(accel);
                if (Input.GetKey(KeyCode.W)) forwardThrust(accel);
                if (Input.GetKey(KeyCode.S)) backThrust(accel);
                if (Input.GetKey(KeyCode.Q)) leftThrust(accel);
                if (Input.GetKey(KeyCode.E)) rightThrust(accel);
                if (Input.GetKey(KeyCode.A)) leftYaw(accel / 2);
                if (Input.GetKey(KeyCode.D)) rightYaw(accel / 2);
            }
        }


    }

    void thrust(Transform thrustPos, float magnitude, Vector3 dir)
    {
        rig.AddForceAtPosition(dir * magnitude, thrustPos.position);
    }

    void thrustAll(float magnitude)
    {
        thrust(top_forwl, magnitude, top_forwl.up);
        thrust(top_backl, magnitude, top_backl.up);
        thrust(top_forwr, magnitude, top_forwr.up);
        thrust(top_backr, magnitude, top_backr.up);
    }

    void forwardPitch(float magnitude)
    {
        thrust(top_backl, magnitude, top_backl.up);
        thrust(top_backr, magnitude, top_backr.up);
        thrust(top_forwr, -magnitude, top_forwr.up);
        thrust(top_forwl, -magnitude, top_forwl.up);
    }

    void backPitch(float magnitude)
    {
        thrust(top_forwl, magnitude, top_forwl.up);
        thrust(top_forwr, magnitude, top_forwr.up);
        thrust(top_backl, -magnitude, top_backl.up);
        thrust(top_backr, -magnitude, top_backr.up);
    }

    void rightRoll(float magnitude)
    {
        thrust(top_forwl, magnitude, top_forwl.up);
        thrust(top_backl, magnitude, top_backl.up);
        thrust(top_backr, -magnitude, top_backr.up);
        thrust(top_forwr, -magnitude, top_forwr.up);
    }

    void leftRoll(float magnitude)
    {
        thrust(top_backr, magnitude, top_backr.up);
        thrust(top_forwr, magnitude, top_forwr.up);
        thrust(top_forwl, -magnitude, top_forwl.up);
        thrust(top_backl, -magnitude, top_backl.up);
    }

    void forwardThrust(float magnitude)
    {
        thrust(bottom_forwl, magnitude, bottom_forwl.forward);
        thrust(bottom_forwr, magnitude, bottom_forwr.forward);
        thrust(bottom_backl, -magnitude, bottom_backl.forward);
        thrust(bottom_backr, -magnitude, bottom_backr.forward);
    }

    void backThrust(float magnitude)
    {
        thrust(bottom_forwl, -magnitude, bottom_forwl.forward);
        thrust(bottom_forwr, -magnitude, bottom_forwr.forward);
        thrust(bottom_backl, magnitude, bottom_backl.forward);
        thrust(bottom_backr, magnitude, bottom_backr.forward);
    }

    void rightThrust(float magnitude)
    {
        thrust(bottom_forwl, magnitude, bottom_forwl.forward);
        thrust(bottom_forwr, -magnitude, bottom_forwr.forward);
        thrust(bottom_backl, magnitude, bottom_backl.forward);
        thrust(bottom_backr, -magnitude, bottom_backr.forward);
    }

    void leftThrust(float magnitude)
    {
        thrust(bottom_forwl, -magnitude, bottom_forwl.forward);
        thrust(bottom_forwr, magnitude, bottom_forwr.forward);
        thrust(bottom_backl, -magnitude, bottom_backl.forward);
        thrust(bottom_backr, magnitude, bottom_backr.forward);
    }

    void rightYaw(float magnitude)
    {
        thrust(bottom_forwl, magnitude, bottom_forwl.forward);
        thrust(bottom_forwr, -magnitude, bottom_forwr.forward);
        thrust(bottom_backl, -magnitude, bottom_backl.forward);
        thrust(bottom_backr, magnitude, bottom_backr.forward);
    }

    void leftYaw(float magnitude)
    {
        thrust(bottom_forwl, -magnitude, bottom_forwl.forward);
        thrust(bottom_forwr, magnitude, bottom_forwr.forward);
        thrust(bottom_backl, magnitude, bottom_backl.forward);
        thrust(bottom_backr, -magnitude, bottom_backr.forward);
    }
}
