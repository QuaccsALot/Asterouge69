using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitShop : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    private void OnMouseDown()
    {
        SceneManager.LoadScene("Gameplay");
    }
    void Update()
    {
        
    }
}
