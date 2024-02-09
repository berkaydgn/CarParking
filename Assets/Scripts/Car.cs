using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Car : MonoBehaviour
{
    public bool Move;
    bool startingPointCase;

    public GameObject[] Trails;
    public Transform Parent;
    public GameManager _GameManager;
    public GameObject ExplosionPoint; 
  

    void Update()
    {
        if (!startingPointCase)
        {
            transform.Translate(8f * Time.deltaTime * transform.forward);
        }
        if (Move)
        {
            transform.Translate(15f * Time.deltaTime * transform.forward);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Parking"))
        {
            VehicleTechnical();
            transform.SetParent(Parent);
            _GameManager.NewVehicle();

            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }

        else if (collision.gameObject.CompareTag("Vehicle"))
        {
            VehicleTechnical();
            _GameManager.ExplosionEffect.transform.position = ExplosionPoint.transform.position;
            _GameManager.ExplosionEffect.Play();
            _GameManager.Lose();
        }
    }
    
    void VehicleTechnical()
    {
        Move = false;
        Trails[0].SetActive(false);
        Trails[1].SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("StartingPoint"))
        {
            startingPointCase = true;
        }

        else if (other.gameObject.CompareTag("Diamond"))
        {
            other.gameObject.SetActive(false);
            _GameManager.Audios[0].Play();
            _GameManager.DiamondCount++;
        }

        else if (other.gameObject.CompareTag("MiddleCenter"))
        {
            VehicleTechnical();
            _GameManager.ExplosionEffect.transform.position = ExplosionPoint.transform.position;
            _GameManager.ExplosionEffect.Play();
            _GameManager.Lose();
        }

        else if (other.gameObject.CompareTag("FirstPark"))
        {
            other.gameObject.GetComponent<FirstPark>().ParkingActive();
        }

    }

}
