using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombLOCAL : MonoBehaviour
{ 

    public GameObject prefab;
    public float speed;
    public float lifetime;

    private float timeSoFar;
    private List<GameObject> pellets = new List<GameObject>();

    GameObject CreateDefaultPewPew(float deltaAngle)
    {
        GameObject newnew = Instantiate(prefab, transform.position, Quaternion.identity);



        // Step 1: Get direction to (0, 0)
        Vector3 direction = transform.up;

        // Step 2: Rotate to face that direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f + deltaAngle;
        newnew.transform.rotation = Quaternion.Euler(0f, 0f, angle);


        newnew.GetComponent<bullet>().speed = speed;
        newnew.GetComponent<bullet>().lifeTime = lifetime;
        // newnew.GetComponent<bullet>().unlimitedPierce = unlimitedPierce;

        newnew.transform.parent = transform;

        return newnew;
    }








    IEnumerator DestroyAfterFrame()
    {
        yield return null; // Wait for one frame


        foreach (var item in pellets)
        {
            item.transform.parent = null;
        }

        Audio.playaudio("bomb");

        Destroy(gameObject); // Destroy the GameObject this script is attached to   
    }





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.parent = null;

        timeSoFar += Time.deltaTime;

        if (timeSoFar >= lifetime)
        {
            for (int i = 0; i < 360; i += 60)
            {
                pellets .Add(CreateDefaultPewPew(i));
            }

            StartCoroutine(DestroyAfterFrame());
        }
    }
}
