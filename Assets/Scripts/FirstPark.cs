using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPark : MonoBehaviour
{
    public GameObject Parking;

    public void ParkingActive()
    {
        Parking.SetActive(true);
    }
}
