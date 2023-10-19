using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BallGyro : MonoBehaviour
{
    public float hiz = 100f; // Topun hareket h�z�

    void Update()
    {
        // Telefonun gyroscope verilerini al
        Vector3 gyroscopeVeri = Input.gyro.rotationRateUnbiased;

        // Hareket vekt�r�n� olu�tur
        Vector3 hareket = new Vector3(0, 0, gyroscopeVeri.y);

        // Hareketi d�zg�nle�tir ve h�zla �arp
        hareket = hareket.normalized * hiz * Time.deltaTime;

        // Rigidbody bile�eni varsa, fizik tabanl� hareket i�in kullan
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(hareket);
        }
        else
        {
            // Rigidbody bile�eni yoksa, do�rudan transform ile hareket ettir
            transform.Translate(hareket);
        }
    }
}




