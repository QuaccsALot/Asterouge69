using UnityEngine;
using UnityEngine.SceneManagement;

public class oopsies : MonoBehaviour
{
    public GameObject player;

    public int respCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (player.active == false)
        {
            print("respawned");
            player.SetActive(true);
            respCount++;
        }

        if(respCount >= 3)
        {
            SceneManager.LoadScene("GameOver");
        }


    }
}
