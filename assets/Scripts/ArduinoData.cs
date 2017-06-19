using UnityEngine;
using System.Collections;
using System.Threading;
using System.Collections.Generic;
using System.IO.Ports;

public class ArduinoData : MonoBehaviour
{
    public Transform UpperArmL;
    //public string SerialPortNumber = "10";
    public GameObject gun;
    private float moveX;
    private float moveY;
    private float moveZ;

    private float inputX;
    private float inputY;
    private float inputZ;

    //SerialPort sp1 = new SerialPort("\\\\.\\COM10", 9600);
    SerialPort sp1 = new SerialPort("COM8", 9600);

    void Start()
    {
        sp1.Open(); //Open the serial connection to the arduino
        //sp1.WriteTimeout = 10; //Catch after 1 millisecond if no data is sent
        sp1.ReadTimeout = 60;  //Catch after 2 milliseconds if no data is sent
        //sp1.Write("s"); //usefull for the controller on battery. Arduino waits on data before sending data to prevent battery drainage
    }

    void Update()
    {
        try
        {
            string value1 = sp1.ReadLine();
            if (value1 == "pew") //if gun trigger is pressed. only applicable for gun.
            {
                Debug.Log("PEW PEW!");
                gun.GetComponent<GunSmoke>().ArduinoFire = true;
            }
            string[] vec31 = value1.Split(','); //Arduino returns degrees in segments, wich are separated by commas.
            if (vec31[0] != "" && vec31[1] != "" && vec31[2] != "") //Check if all values are recieved
            {
                //print the values read directly from arduino
                Debug.Log(value1);

                //parse them as floats and assign them to var inputX, inputY and inputZ
                inputX = float.Parse(vec31[0]);
                inputY = float.Parse(vec31[0]);
                inputZ = float.Parse(vec31[0]);

                

                UpperArmL.localEulerAngles = new Vector3(inputX, inputY, inputZ);
            }
        }
        catch (System.Exception)
        {
        }
    }
}