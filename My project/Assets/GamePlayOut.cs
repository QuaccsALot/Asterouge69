using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayOut : MonoBehaviour
{
    public float timeToShop = 59f;
    public TMP_Text timeText;

    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = timeToShop;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);

        string formattedTime = string.Format("{0}:{1:00}", minutes, seconds);


        timeText.text = formattedTime;




        if (timer <= 0)
        {
            print("going to shop");
            SceneManager.LoadScene("ShopUI2");
        }
    }
}
