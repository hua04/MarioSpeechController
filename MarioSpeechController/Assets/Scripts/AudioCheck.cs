using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class AudioCheck : MonoBehaviour
{
    SerialPort serialPort;
    public int audioLevel;
    public bool yellow;
    public bool red;
    public bool blue;
    public bool green;

    void Start()
    {
        serialPort = new SerialPort("COM3", 9600);
        serialPort.Open();
    }

    void Update()
    {
        if (serialPort.IsOpen)
        {
            
            try
            {
                string data = serialPort.ReadLine();
                print(data);
                //sensorValue = int.Parse(data);
                if (data[0].ToString() == "A")//If its audio data
                {
                    string result = data.Replace("A", "");
                    audioLevel = int.Parse(result);

                    //put audio variable update here
                } else if (data[0].ToString() == "B")
                {
                    //if its button data
                    if (data[1].ToString() == "1")
                    {
                        yellow = false;
                    } else
                    {
                        yellow = true;
                    }

                    if (data[3].ToString() == "1")
                    {
                        red = false;
                    } else
                    {
                        red = true;
                    }
                    if (data[5].ToString() == "1")
                    {
                        blue = false;
                    }
                    else
                    {
                        blue = true;
                    }
                    if (data[7].ToString() == "1")
                    {
                        green = false;
                    }
                    else
                    {
                        green = true;
                    }
                }
              
                    Debug.Log( yellow +", "+ red + ", " + blue + ", " + green);


            }
            catch (System.Exception)
            {
                // Handle exceptions
            }

          
        }

       

    }
}
