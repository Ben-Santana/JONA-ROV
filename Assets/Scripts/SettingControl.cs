using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingControl : MonoBehaviour
{

    public GameObject Setting;
    private bool setVis = true;
    // Start is called before the first frame update
    void Start()
    {
        Setting.SetActive(setVis);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            setVis = !setVis;
            Setting.SetActive(setVis);
        }
    }
}
