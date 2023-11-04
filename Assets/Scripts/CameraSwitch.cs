using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{

    public GameObject[] Cameras;
    public int Manager;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject c in Cameras)
        {
            if (c != Cameras[0]) c.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) ManageCamera();
    }

    void ManageCamera()
    {

        foreach (GameObject c in Cameras)
        {
            if (c != Cameras[Manager]) c.SetActive(false);
            else c.SetActive(true);
        }
        if (Manager == Cameras.Length - 1) Manager = 0;
        else Manager++;

    }
}
