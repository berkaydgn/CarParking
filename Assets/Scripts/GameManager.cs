using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [Header("----VEHICLE SETTINGS")]
    public GameObject[] Vehicles;
    public GameObject StartingPoint;
    public int numberOfVehicles;
    int ActiveVehicleIndex;

    [Header("----PLATFORM SETTINGS")]
    public GameObject Platform_1;
    public GameObject Platform_2;
    public float[] RotationSpeed;

    void Start()
    {
 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Vehicles[ActiveVehicleIndex].GetComponent<Car>().Move = true;
            ActiveVehicleIndex++;
        }

        Platform_1.transform.Rotate(new Vector3(0, 0, RotationSpeed[0]), Space.Self);

    }

    public void NewVehicle()
    {
        if (ActiveVehicleIndex < numberOfVehicles)
        {
            Vehicles[ActiveVehicleIndex].SetActive(true);
            StartingPoint.SetActive(true);
        }
    }



}

