using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class score : MonoBehaviour
{
    
    public int numba = 0;
    
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject text = gameObject;
        TMP_Text score = text.GetComponent<TMP_Text>();
        score.text = "Score:" + numba;

    }
}
