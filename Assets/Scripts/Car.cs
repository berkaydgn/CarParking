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
    
    void Start()
    {
        
    }

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
        if (collision.gameObject.CompareTag("StartingPoint"))
        {
            startingPointCase = true;
            _GameManager.StartingPoint.SetActive(false);
        }

        else if (collision.gameObject.CompareTag("Parking"))
        {
            Move = false;
            Trails[0].SetActive(false);
            Trails[1].SetActive(false);
            transform.SetParent(Parent);
            _GameManager.NewVehicle();

            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }

        else if (collision.gameObject.CompareTag("MiddleCenter"))
        {
            Destroy(gameObject);     //I will create the object pool later
        }

        else if (collision.gameObject.CompareTag("Vehicle"))
        {
            Destroy(gameObject);     //I will create the object pool later
        }

    }
}
