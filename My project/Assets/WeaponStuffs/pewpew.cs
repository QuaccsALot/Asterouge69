using System.Collections.Generic;
using UnityEngine;

public class pewpew : MonoBehaviour

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Space(50)]
    public GameObject player;
    public GameObject pelletPrefab;

    [Space(50)]
    public float shotgun_speedMult = .5f;
    public float shotgun_lifetimeMult = .4f;

    [Space(50)]
    public float sniper_lifetimeMult = 3f;
    public float sniper_speedMult = 1.05f;
    public float sniper_timeToShootMult = 5f;

    [Space(50)]
    public float bomb_timeToShoot = 3f;
    public GameObject bomb_prefab;
    public float bomb_forceForward = 5f;
    public float bomb_lifetime = .75f;
    public float bomb_speed;     //please note; also gets the the player and prefab variables auto : D 

    [Space(50)]
    public bool break_isOn;
    [Range(0, 100)] public float break_strength;

    [Space(50)]
    public float speed = 1f;
    public float lifetime = .5f;

    public float timeToShoot = .25f;

    public bool unlimitedPierce = false;



    [Header("private / debug")]
    private float timeSINCEShoot = 0f;
    private Rigidbody2D _rb;

    private Dictionary<string, object>  initialPewPew;





    void Start()
    {
        initialPewPew = new Dictionary<string, object>();
        
        // Get all public instance fields
        var fields = this.GetType().GetFields();
        foreach (var field in fields)
        {
            initialPewPew[field.Name] = field.GetValue(this);
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////

    GameObject CreateDefaultPewPew(float deltaAngle)
    {
        GameObject newnew = Instantiate(pelletPrefab, transform.position, Quaternion.identity);



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
            Audio.playaudio("Shoot");

        }



        timeSINCEShoot += Time.deltaTime;
    }














    //////////////////////////////////////////////////////////////////////////////////////////////////////



    void CM_shotgunStart()
    {
        speed *= shotgun_speedMult;
        lifetime *= shotgun_lifetimeMult;
    }




    void CM_shotgunUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateDefaultPewPew(30f);
            CreateDefaultPewPew(-30f);
        }



        //TO DO: THIS WILL BREAK THINGS FOR SNIPER + SHOTGUN, ONLY FOR TESTING!!!

        speed = (float)initialPewPew["speed"];
        speed *= shotgun_speedMult;

        lifetime = (float)initialPewPew["lifetime"];
        lifetime *= shotgun_lifetimeMult;
    }










    //////////////////////////////////////////////////////////////////////////////////////////////////////








    void CM_sniperStart()
    {
        lifetime = (float)initialPewPew["lifetime"];
        lifetime *= sniper_lifetimeMult;

        speed = (float)initialPewPew["speed"];
        speed *= sniper_speedMult;


        timeToShoot = (float)initialPewPew["timeToShoot"];
        timeToShoot *= sniper_timeToShootMult;

        unlimitedPierce = true;
    }




    void CM_sniperUpdate()
    {
        ////TO DO: THIS WILL BREAK THINGS FOR SNIPER + SHOTGUN, ONLY FOR TESTING!!!

        lifetime = (float)initialPewPew["lifetime"];
        lifetime *= sniper_lifetimeMult;

        speed = (float)initialPewPew["speed"];
        speed *= sniper_speedMult;


        timeToShoot = (float)initialPewPew["timeToShoot"];
        timeToShoot *= sniper_timeToShootMult;

        unlimitedPierce = true;
    }






    //////////////////////////////////////////////////////////////////////////////////////////////////////''



    void CM_bombStart()
    {
        bombCREATER bomb = gameObject.AddComponent(typeof(bombCREATER)) as bombCREATER;
        bomb.prefab = bomb_prefab;
        bomb.player = player;
        bomb.pelletGameObject = pelletPrefab;


        bomb.timeToShoot = bomb_timeToShoot;

        bomb.forceForward = bomb_forceForward;

        bomb.lifetime = bomb_lifetime;

        bomb.speed = bomb_speed;

        // this.enabled = false;
    }


    void CM_bombUpdate()
    {
        bombCREATER bomb = GetComponent<bombCREATER>();
        bomb.timeToShoot = bomb_timeToShoot;

        bomb.forceForward = bomb_forceForward;

        bomb.lifetime = bomb_lifetime;

        bomb.speed = bomb_speed;
    }











    //////////////////////////////////////////////////////////////////////////////////////////////////////''




    void CM_breakStart()
    {
        break_isOn = true;
        _rb = transform.root.GetComponent<Rigidbody2D>();
    }



    void LateUpdate()
    {
        // Brake if down arrow is held
        if (Input.GetKey(KeyCode.DownArrow) && break_isOn)
        {
            _rb.linearVelocity *= (100 - break_strength) / 100;
        }
    }




}
