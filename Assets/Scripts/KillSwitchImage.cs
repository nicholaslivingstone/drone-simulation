using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillSwitchImage : MonoBehaviour
{

    public static bool isOn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("j")) {
            if(isOn) isOn = false;
            else isOn = true;
        }

        if (isOn) {
            GetComponent<Image>().color = Color.green;
        }
        else {
            GetComponent<Image>().color = Color.red;
        }
    }
}
