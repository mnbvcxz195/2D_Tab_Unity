using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFrefControl : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("testKey", 2);

        Debug.Log(PlayerPrefs.HasKey("testKey"));
        Debug.Log(PlayerPrefs.GetInt("testKey"));
    }

}
