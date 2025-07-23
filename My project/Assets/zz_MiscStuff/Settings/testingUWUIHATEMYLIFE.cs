using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testingUWUIHATEMYLIFE : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //print(ConnectionManager.CURRENTscore)
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("ShopUI2");
        }
    }
}
