using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BallGyro : MonoBehaviour
{
    public float hiz = 100f; // Topun hareket hýzý

    void Update()
    {
        // Telefonun gyroscope verilerini al
        Vector3 gyroscopeVeri = Input.gyro.rotationRateUnbiased;

        // Hareket vektörünü oluþtur
        Vector3 hareket = new Vector3(0, 0, gyroscopeVeri.y);

        // Hareketi düzgünleþtir ve hýzla çarp
        hareket = hareket.normalized * hiz * Time.deltaTime;

        // Rigidbody bileþeni varsa, fizik tabanlý hareket için kullan
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(hareket);
        }
        else
        {
            // Rigidbody bileþeni yoksa, doðrudan transform ile hareket ettir
            transform.Translate(hareket);
        }
    }
}




