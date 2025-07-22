using System.Collections.Generic;
using UnityEngine;

public class pewpew : MonoBehaviour

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("General")]
    public GameObject player;
    public GameObject prefab;


    [Header("Bomb")]
    public GameObject bombPrefab;


    [Header("Break")]
    public bool break_isOn;
    [Range(0, 1000)] public float break_slowDown;

    [Header("Settings")]
    public float speed = 1f;
    public float lifetime = .5f;

    public float timeToShoot = .25f;

    public bool unlimitedPierce = false;



    private float timeSINCEShoot = 0f;


    public List<string> modifiers;



    public Rigidbody2D _rb;



    //////////////////////////////////////////////////////////////////////////////////////////////////////

    GameObject CreateDefaultPewPew(float deltaAngle)
    {
        GameObject newnew = Instantiate(prefab, transform.position, Quaternion.identity);



        // Step 1: Get direction to (0, 0)
        Vector3 direction = (transform.position - player.transform.position).normalized;

        // Step 2: Rotate to face that direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f + deltaAngle;
        newnew.transform.rotation = Quaternion.Euler(0f, 0f, angle);


        newnew.GetComponent<bullet>().speed = speed;
        newnew.GetComponent<bullet>().lifeTime = lifetime;
        newnew.GetComponent<bullet>().unlimitedPierce = unlimitedPierce;

        return newnew;
    }





    //////////////////////////////////////////////////////////////////////////////////////////////////////


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && timeSINCEShoot >= timeToShoot)
        {
            timeSINCEShoot = 0;

            GameObject pewpew = CreateDefaultPewPew(0);

        }



        timeSINCEShoot += Time.deltaTime;
    }














    //////////////////////////////////////////////////////////////////////////////////////////////////////



    void CM_shotgunStart()
    {
        speed *= .25f;
        lifetime *= .125f * (.8f / .25f);
    }




    void CM_shotgunUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateDefaultPewPew(30f);
            CreateDefaultPewPew(-30f);
        }
    }










    //////////////////////////////////////////////////////////////////////////////////////////////////////








    void CM_sniperStart()
    {
        lifetime *= 3f;
        speed *= 1.05f;

        timeToShoot *= 5f;

        unlimitedPierce = true;
    }






    //////////////////////////////////////////////////////////////////////////////////////////////////////''



    void CM_bombStart()
    {
        bombCREATER bomb = gameObject.AddComponent(typeof(bombCREATER)) as bombCREATER;
        // this.enabled = false;
    }











    //////////////////////////////////////////////////////////////////////////////////////////////////////''




    void CM_breakStart()
    {
        break_isOn = true;
        _rb = transform.root.GetComponent<Rigidbody2D>();
    }



    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.DownArrow) && break_isOn)
        {
            _rb.linearDamping = 10f;
        }
    }




}
