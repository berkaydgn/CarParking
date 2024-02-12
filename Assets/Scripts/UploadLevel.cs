using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UploadLevel : MonoBehaviour
{
    void Start()
    {
        if (!PlayerPrefs.HasKey("Diamond"))
        {
            PlayerPrefs.SetInt("Diamond", 0);
            PlayerPrefs.SetInt("Level", 1);
        }

        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
    }


}
