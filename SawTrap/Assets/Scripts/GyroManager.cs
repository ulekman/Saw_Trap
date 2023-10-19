using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroManager : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;
    private Quaternion initialGyroRotation;
    private Quaternion offsetRotation;

    private void Start()
    {
        
        gyroEnabled = EnableGyro();

        if (gyroEnabled)
        {
            
            Input.gyro.updateInterval = 0.01f;
            
            initialGyroRotation = Quaternion.Euler(90f, 0f, 0f) * (new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, Input.gyro.attitude.z, Input.gyro.attitude.w));

            offsetRotation = Quaternion.Inverse(initialGyroRotation);
        }
        else
        {
            Debug.Log("Cihazýnýzda gyroskop bulunmamaktadýr veya etkin deðildir.");
        }
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }
        return false;
    }

    private void Update()
    {
        if (gyroEnabled)
        {
           
            Quaternion currentGyroRotation = Quaternion.Euler(90f, 0f, 0f) * (new Quaternion(Input.gyro.attitude.x,  0f, Input.gyro.attitude.y, Input.gyro.attitude.w));
            

            Quaternion adjustedRotation = offsetRotation * currentGyroRotation;
            transform.rotation = adjustedRotation ;
        }
    }
}
