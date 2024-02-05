using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [Header("----VEHICLE SETTINGS")]
    public GameObject[] Vehicles;
    public GameObject StartingPoint;
    public int numberOfVehicles;
    int ActiveVehicleIndex;

    [Header("----CANVAS SETTINGS")]
    public Sprite GreenVehicleSprite;
    public GameObject[] VehicleSprites;

    [Header("----PLATFORM SETTINGS")]
    public GameObject Platform_1;
    public GameObject Platform_2;
    public float[] RotationSpeed;

    [Header("----LEVEL SETTINGS")]
    public int DiamondCount;


    void Start()
    {
        //for (int i = 0; i < numberOfVehicles; i++)
        //{
        //    VehicleSprites[i].SetActive(true);
        //}
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

        //VehicleSprites[ActiveVehicleIndex - 1].GetComponent<Image>().sprite = GreenVehicleSprite;
    }



}

