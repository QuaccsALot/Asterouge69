using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class oopsies : MonoBehaviour
{

    [Header("actual respawn")]
    public GameObject player;
    public int totalRespawns = 3;
    public float invincibleTime = 1f;

    public string currentState = "playing"; //playing, invincible

    public Color32 invinsibleColor;


    [Header("showing respawns")]
    public GameObject modelForShowingRespawns;
    public float dist = 5f;
    public Transform anchor;

    private List<GameObject> models = new List<GameObject>();

    [Header("Debug")]
    public float invincibleCount = 0f;
    public int respCount = 0;
    public SpriteRenderer playerModel;
    public PlayerController playerController;
    public Color32 baseColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        playerModel = playerController.model.GetComponent<SpriteRenderer>();
        baseColor = playerModel.material.color;


        for (int i = 0; i < totalRespawns; i++)
        {
            GameObject newObj = Instantiate(modelForShowingRespawns, anchor.right * dist * i + anchor.position, Quaternion.identity);
            newObj.transform.parent = anchor;
            models.Add(newObj);
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (player.active == false)
        {
            print("respawned");
            player.SetActive(true);
            playerController.invinsible = true;

            playerController.ResetEverything = true;

            currentState = "invincible";
            respCount++;


            try
            {
                Destroy(models[models.Count - 1]);
                models.RemoveAt(models.Count - 1);
            }
            catch { }
            
        }





        if (currentState == "invincible")
        {
            invincibleCount += Time.deltaTime;

            Color32 color = Color32.Lerp(invinsibleColor, baseColor, invincibleCount / invincibleTime);
            color.a = invinsibleColor.a;
            playerModel.material.color = color;



            if (invincibleCount >= invincibleTime)
            {
                currentState = "playing";
                invincibleCount = 0f;
                playerController.invinsible = false;

                playerModel.material.color = baseColor;
            }
        }

        






        if (respCount > totalRespawns)
        {
            SceneManager.LoadScene("GameOver");
        }
        
        

    }
}
