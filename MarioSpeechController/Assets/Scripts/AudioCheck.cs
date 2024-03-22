using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class AudioCheck : MonoBehaviour
{
    SerialPort sp = new SerialPort("/dev/cu.usbmodem11401", 9600);
    private int sensorValue;

    void Start()
    {
        sp.Open();
    }

    void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                string data = sp.ReadLine();
                sensorValue = int.Parse(data);
                Debug.Log(sensorValue);
                //Debug.Log("Received: " + data);
            }
            catch (System.Exception)
            {
                // Handle exceptions
            }
        }

    }
}
