using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{

    public void Clicked()
    {

        SceneManager.LoadScene("Main Menu");

    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
