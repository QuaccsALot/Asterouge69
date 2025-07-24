using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class SceenShake : MonoBehaviour
{


    public Transform camera;
    public float defaultTimeForShake = .25f;
    public float intensity = .25f;



    [HideInInspector]
    public static SceenShake instance;





    [Header("Debug")]
    public Vector3 initialForm;
    public float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        initialForm = camera.position;


        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            Vector3 newPos = initialForm;
            newPos.x += Random.Range(-intensity, intensity);
            newPos.y += Random.Range(-intensity, intensity);

            camera.position = newPos;

            timer -= Time.deltaTime;
        }
        else
        {
            camera.position = initialForm;
            timer = 0f;
        }

    }







    public static void ScreenShake(float deltaCounter)
    {
        print("cum");


        if (deltaCounter >= 0)
        {
            instance.timer += deltaCounter;
        }
        else
        {
            deltaCounter = instance.defaultTimeForShake;
            instance.timer += deltaCounter;
        }
    }
}
