using System.Data.SqlTypes;
using UnityEngine;
using TMPro;
using Unity.Jobs;
using UnityEditor.Experimental.GraphView;
using UnityEngine.EventSystems;
using UnityEditor;
using Unity.Mathematics;
using UnityEditor.Rendering;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using System.Runtime.CompilerServices;
using Random = UnityEngine.Random;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine.UI;

public class Purchaseable : MonoBehaviour
{
    //-----------------------------
    //def global vars
    //replace Temp Vars with Real Vars
    [Header("General")]
    public bool TopOrBottom = false;

    [Header("Stuffs")]
    public TMP_Text PriceText;
    public ParticleSystem CanBuyParts;
    public powerUp powerUpData;
    public TMP_Text Signtext;

    [Header("private stuffs")] //not shown
    private float jiggleReducer = 0;
    private float ExpandedSize = 0;
    private float basesizeX = 0;
    private float basesizeY = 0;
    private float SizeMult = 0;
    private int PierceAdd = 0;
    private float LifeMult = 0;
    private float SpeedMult = 0;
    private bool AbilityOrBoost = false;
    byte baseR = 0;
    byte baseG = 0;
    byte baseB = 0;
    public bool Canbuy = false;
    private bool Sold = false;
    private bool PartsPlaying = false;
    public int temprarity = 0;
    private int temprarity2 = 0;



    //---------------------------------------------------------Start down
    void Start()
    {
        powerUpData = new powerUp();

        int rand = Random.Range(0, 2);
        switch (rand)
        {
            case 0:
                AbilityOrBoost = false;
                break;

            case 1:
                AbilityOrBoost = true;
                break;

            default:
                Debug.LogError("YOOOO I FUCKED IT");
                break;
        }


        Transform parentTransform = transform.parent;
        Signtext = transform.parent.transform.parent.Find("sign text").GetComponent<TMP_Text>();
        PriceText = transform.parent.GetComponentInChildren<TMP_Text>();
        basesizeX = transform.localScale.x;
        basesizeY = transform.localScale.y;
        if  (TopOrBottom)
        {
            temprarity = Random.Range(9, 17);
        }
        else
        { temprarity = Random.Range(0, 15); }



        if (temprarity <= 7)
        {

            if (AbilityOrBoost)
            {
                powerUpData = ConnectionManager.GetRandomAbilOfRarity(0);
            }
            else {
                SpeedMult = .2f;
                LifeMult = .5f;
            }
            temprarity2 = 0;
        }
        else if (temprarity <= 12)
        {
            if (AbilityOrBoost)
            {
                powerUpData = ConnectionManager.GetRandomAbilOfRarity(1);
            }
            else { SizeMult = .5f; }
            temprarity2 = 1;
        }
        else if (temprarity <= 15)
        {
            if (AbilityOrBoost)
            {
                print("69420 = 67");
                powerUpData = ConnectionManager.GetRandomAbilOfRarity(2);
            }
            else {
                SpeedMult = .3f;
                PierceAdd = 1;
            }
            temprarity2 = 2;
        }
        else
        {
            if (AbilityOrBoost)
            {
                powerUpData = ConnectionManager.GetRandomAbilOfRarity(3);
            }
            else
            {
                SpeedMult = .2f;
                LifeMult = .25f;
                SizeMult = .5f;
                PierceAdd = 1;
                
            }
            temprarity2 = 3;
        }

        if (temprarity2 is 0)
        {
            baseR = 136;
            baseG = 255;
            baseB = 0;
            powerUpData.price = 4000;
        }
        else if (temprarity2 is 1)
        {
            baseR = 0;
            baseG = 215;
            baseB = 255;
            powerUpData.price = 6000;
        }
        else if (temprarity2 is 2)
        {
            baseR = 170;
            baseG = 0;
            baseB = 255;
            powerUpData.price = 9000;
        }
        else if (temprarity2 is 3)
        {
            baseR = 255;
            baseG = 170;
            baseB = 0;
            powerUpData.price = 13000;

        }
        PriceText.text = new string("$" + powerUpData.price);

        CanBuyParts.startColor = new Color32(baseR, baseG, baseB, 50);
        CanBuyParts.startLifetime = .5f;
        CanBuyParts.Play(true);
        PartsPlaying = true;

    }
    //---------------------------------------------------------Start up
    //effects when hover over
    void OnMouseOver()
    {
        if (Canbuy)
        {
            jiggleReducer = jiggleReducer + 10;
            ExpandedSize = ExpandedSize + 1;
            CanBuyParts.startLifetime = 1f;
            CanBuyParts.startColor = new Color32(baseR, baseG, baseB, 200);
            if (AbilityOrBoost) { Signtext.text = new string("" + powerUpData.name + " - " + powerUpData.summary); }
            else
            {
                Signtext.text = new string("+" + SizeMult +"X Bullet Size,   +" + LifeMult + "X Bullet Lifetime,   +" + SpeedMult + "X Bullet Speed,   +"+ PierceAdd + " Pierce" );
            }
        }

    }
    private void OnMouseExit()
    {
        CanBuyParts.startLifetime = .5f;
        CanBuyParts.startColor = new Color32(baseR, baseG, baseB, 50);
    }
    //-----------------------------
    //purchase effects
    private void OnMouseDown()
    {
        if (ConnectionManager.CURRENTscore >= powerUpData.price)
        {
            if (AbilityOrBoost) 
            { 
                ConnectionManager.AddPowerUp(powerUpData.name);
            }
            else
            {
                ConnectionManager.ADDpierce = ConnectionManager.ADDpierce + PierceAdd;
                ConnectionManager.lifetimeMult = ConnectionManager.lifetimeMult + LifeMult;
                ConnectionManager.scaleMult = ConnectionManager.scaleMult + SizeMult;
                ConnectionManager.SpeedMult = ConnectionManager.SpeedMult + SpeedMult;
            }

            Sold = true;
            CanBuyParts.Stop();
            PartsPlaying = false;
            PriceText.text = "SOLD";

            print("bought");
        }

    }
    //---------------------------------------------------------updates down
    void Update()
    {
        //Checks if its purchasable
        if (ConnectionManager.CURRENTscore >= powerUpData.price)
        {
            Canbuy = true;
        }
        else
        {
            Canbuy = false;
        }
        if (Sold)
        {
            Canbuy = false;
        }
        //-----------------------------
        // Particle Emmitter
        if (!Canbuy)
        {
            CanBuyParts.Stop(true);
            // Debug.Log("suppose to stop parts");
            PartsPlaying = false;
        }
        else if (!PartsPlaying) 
        {
            CanBuyParts.Play(true);
            // Debug.Log("suppose to play parts");
            PartsPlaying = true;
        }
        //-----------------------------
        //appling hover effects
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * 3) * jiggleReducer / 5);
        transform.localScale = new Vector3(basesizeX + ExpandedSize / 20, basesizeY + ExpandedSize / 10);
        if (jiggleReducer >= .5)
        {
            jiggleReducer = jiggleReducer - 1;
        }
        if (jiggleReducer >= 60)
        {
            jiggleReducer = 60;
        }
        if (ExpandedSize >= 1)
        {
            ExpandedSize = ExpandedSize - .5f;
        }
        if (ExpandedSize >= 10)
        {
            ExpandedSize = 10;
        }
        //-----------------------------
    }
    //---------------------------------------------------------updates up






}
