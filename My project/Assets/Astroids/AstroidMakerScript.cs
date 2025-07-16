using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class AstroidMakerScript : MonoBehaviour
{

    [SerializeField, Header("General")]
    private float timeToSpawn = 10f;
    [SerializeField]
    private List<Vector3> twoPointsToDefPlace = new List<Vector3>();
    [SerializeField]
    private float forceAmount = 1;


    [SerializeField]
    private GameObject prefab;


    [SerializeField, Header("Debug bc I'm DUM DUM"), Space(20)]
    private float timeSinceSpawn = 0;


    void SPAWNTHINGY()
    {
        Vector3 startPoint = twoPointsToDefPlace[0];
        Vector2 endPoint = twoPointsToDefPlace[1];

        int side = (int)Mathf.Floor(Random.Range(0, 3));
        float randomLerp = Random.Range(0, 100) / 100f;
        print(randomLerp);

        Vector3 newPos = Vector3.zero;

        switch (side)
        {
            case 0:
                newPos.y = startPoint.y;
                break;
            case 1:
                newPos.x = endPoint.x;
                break;
            case 2:
                newPos.y = endPoint.y;
                break;
            case 3:
                newPos.y = endPoint.x;
                break;
        }

        if (newPos.x == 0)
        {
            newPos.x = Mathf.Lerp(startPoint.x, endPoint.x, randomLerp);
        }
        else if (newPos.y == 0)
        {
            newPos.y = Mathf.Lerp(startPoint.y, endPoint.y, randomLerp);
        }





        GameObject newAstroid = Instantiate(prefab, newPos, Quaternion.identity);
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;

        if (timeSinceSpawn > timeToSpawn)
        {
            SPAWNTHINGY();
            timeSinceSpawn = 0;
        }
    }
}
