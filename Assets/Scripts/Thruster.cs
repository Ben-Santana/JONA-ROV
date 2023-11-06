using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{

    Rigidbody rig;
    public float speed;
    private float vel;
    private bool turningMode = false; // true = yaw |  false = pitch
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
        vel = speed;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab)) turningMode = !turningMode;

        if (turningMode)
        {

            if (Input.GetKey(KeyCode.LeftShift))
            {
                vel = -speed;
            }
            else vel = speed;

            if (Input.GetKey(KeyCode.Space)) thrustAll(vel);
            if (Input.GetKey(KeyCode.W)) forwardPitch(vel / 4);
            if (Input.GetKey(KeyCode.S)) backPitch(vel / 4);
            if (Input.GetKey(KeyCode.A)) leftRoll(vel / 4);
            if (Input.GetKey(KeyCode.D)) rightRoll(vel / 4);

        }
        else
        {

            if (Input.GetKey(KeyCode.LeftShift))
            {
                vel = -speed;
            }
            else vel = speed;


            if (Input.GetKey(KeyCode.Space)) thrustAll(vel);
            if (Input.GetKey(KeyCode.W)) forwardThrust(vel);
            if (Input.GetKey(KeyCode.S)) backThrust(vel);
            if (Input.GetKey(KeyCode.Q)) leftThrust(vel);
            if (Input.GetKey(KeyCode.E)) rightThrust(vel);
            if (Input.GetKey(KeyCode.A)) leftYaw(vel / 2);
            if (Input.GetKey(KeyCode.D)) rightYaw(vel / 2);
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
