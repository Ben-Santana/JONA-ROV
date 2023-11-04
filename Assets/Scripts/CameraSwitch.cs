using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{

    public GameObject Camera_1;
    public GameObject Camera_2;
    public int Manager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) ManageCamera();
    }

    void ManageCamera()
    {
        if (Manager == 1)
        {
            Cam_1();
            Manager = 2;
        }
        else if (Manager == 2)
        {
            Cam_2();
            Manager = 1;
        }
    }

    void Cam_1()
    {
        Camera_1.SetActive(true);
        Camera_2.SetActive(false);
    }

    void Cam_2()
    {
        Camera_2.SetActive(true);
        Camera_1.SetActive(false);
    }
}
