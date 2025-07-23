using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class bombCREATER : MonoBehaviour
{
    public float timeToShoot = 3f;
    public GameObject prefab;
    public float forceForward = 5f;
    public float lifetime = .75f;
    public float speed;


    public GameObject pelletGameObject;

    [Header("Debug")]
    public float timeSINCEShoot = 0f;
    public GameObject player;






    GameObject CraeteBomb()
    {
        GameObject newnew = Instantiate(prefab, transform.position, Quaternion.identity);



        // Step 1: Get direction to (0, 0)
        Vector3 direction = (transform.position - player.transform.position).normalized;

        // Step 2: Rotate to face that direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        newnew.transform.rotation = Quaternion.Euler(0f, 0f, angle);


        newnew.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 0, angle) * forceForward);
        newnew.GetComponent<bombLOCAL>().lifetime = lifetime;
        newnew.GetComponent<bombLOCAL>().prefab = pelletGameObject;
        newnew.GetComponent<bombLOCAL>().speed = speed;

        newnew.transform.parent = transform;

        return newnew;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //all is initialized inside pewpew
    }

    // Update is called once per frame
    void Update()
    {
        timeSINCEShoot += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F) && timeSINCEShoot >= timeToShoot)
        {
            timeSINCEShoot = 0;

            GameObject pewpew = CraeteBomb();
        }
    }
}
