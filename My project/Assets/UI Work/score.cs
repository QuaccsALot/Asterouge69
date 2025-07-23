using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class score : MonoBehaviour
{
    
    public int numba = 0;

    private TMP_Text me;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        me = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        me.text = "Score: " + ConnectionManager.CURRENTscore;

    }
}
