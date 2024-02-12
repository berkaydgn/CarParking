using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [Header("----VEHICLE SETTINGS")]
    public GameObject[] Vehicles;
    public int NumberOfVehicles;
    int NumberOfVehicles2;
    int ActiveVehicleIndex;

    [Header("----CANVAS SETTINGS")]
    public Sprite GreenVehicleSprite;
    public GameObject[] VehicleSprites;
    public TextMeshProUGUI[] Texts;
    public GameObject[] Panels;
    public GameObject[] TTCs;



    [Header("----PLATFORM SETTINGS")]
    public GameObject Platform_1;
    public GameObject Platform_2;
    public float[] RotationSpeed;

    [Header("----LEVEL SETTINGS")]
    public int DiamondCount;
    public ParticleSystem ExplosionEffect;
    bool rotating = true;
    bool tapLock;
    public AudioSource[] Audios;


    void Start()
    {   
         tapLock = true;
         NumberOfVehicles2 = NumberOfVehicles;

        for (int i = 0; i < NumberOfVehicles; i++)
        {
            VehicleSprites[i].SetActive(true);
        } 

        CheckDefaultValue();
    }
    
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {

                if (tapLock)
                {
                    Panels[0].SetActive(false);
                    Panels[3].SetActive(true);
                    tapLock = false;
                }

                else
                {
                    Vehicles[ActiveVehicleIndex].GetComponent<Car>().Move = true;
                    ActiveVehicleIndex++;
                }
            }
        }

        if (rotating)
        {
            Platform_1.transform.Rotate(new Vector3(0, 0, RotationSpeed[0]), Space.Self);
            Platform_2.transform.Rotate(new Vector3(0, 0, -RotationSpeed[1]), Space.Self);
        }
    }

    public void NewVehicle()
    {
        NumberOfVehicles2--;
        if (ActiveVehicleIndex < NumberOfVehicles)
        {
            Vehicles[ActiveVehicleIndex].SetActive(true);
        }
        else
        {
            Win();
        }
        
        VehicleSprites[ActiveVehicleIndex - 1].GetComponent<Image>().sprite = GreenVehicleSprite;
    }

    void Win()
    {
        PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + DiamondCount);

        Texts[2].text = PlayerPrefs.GetInt("Diamond").ToString();
        Texts[3].text = SceneManager.GetActiveScene().name;
        Texts[4].text = (NumberOfVehicles - NumberOfVehicles2).ToString();
        Texts[5].text = DiamondCount.ToString();

        Panels[1].SetActive(true);
        Panels[3].SetActive(false);
        Audios[1].Play();
        rotating = false;

        Invoke("WinTTC", 2f);
    }

   public void Lose()
    {
        Texts[6].text = PlayerPrefs.GetInt("Diamond").ToString();
        Texts[7].text = SceneManager.GetActiveScene().name;
        Texts[8].text = (NumberOfVehicles - NumberOfVehicles2).ToString();
        Texts[9].text = DiamondCount.ToString();

        Panels[2].SetActive(true);
        Panels[3].SetActive(false);

        Audios[2].Play();
        Audios[3].Play();

        rotating = false;

        Invoke("LoseTTC", 2f);
    }

    void WinTTC()
    {
        TTCs[0].SetActive(true);
    }

    void LoseTTC()
    {
        TTCs[1].SetActive(true);
    }

    public void RotationContinue()
    {
        rotating = true;
    }


    //MEMORY MANAGMENT


    void CheckDefaultValue()
    {
        

        Texts[0].text = PlayerPrefs.GetInt("Diamond").ToString();
        Texts[1].text = SceneManager.GetActiveScene().name;   
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("Level" ,SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
