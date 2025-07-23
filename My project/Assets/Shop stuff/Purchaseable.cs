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

    [Header("private stuffs")] //not shown
    private float jiggleReducer = 0;
    private float ExpandedSize = 0;
    private float basesizeX = 0;
    private float basesizeY = 0;
    byte baseR = 0;
    byte baseG = 0;
    byte baseB = 0;
    public bool Canbuy = false;
    private bool Sold = false;
    private bool PartsPlaying = false;
    public int temprarity = 0;



    //---------------------------------------------------------Start down
    void Start()
    {
        powerUpData = new powerUp();
        Transform parentTransform = transform.parent;
        // PriceText = transform.parent.GetComponentInChildren<TMP_Text>();
        basesizeX = transform.localScale.x;
        basesizeY = transform.localScale.y;
        if  (TopOrBottom)
        { temprarity = Random.Range(9, 17); }
        else
        { temprarity = Random.Range(0, 15); }



        if (temprarity <= 7)
        {
            print("0");
            powerUpData = ConnectionManager.GetRandomAbilOfRarity(0);
        }
        else if (temprarity <= 12)
        {
            print("1");
            powerUpData = ConnectionManager.GetRandomAbilOfRarity(1);
        }
        else if (temprarity <= 15)
        {
            print("2");
            powerUpData = ConnectionManager.GetRandomAbilOfRarity(2);
        }
        else
        {
            print("3");
            powerUpData = ConnectionManager.GetRandomAbilOfRarity(3);
        }





        if (powerUpData.rarity is 0)
        {
            baseR = 136;
            baseG = 255;
            baseB = 0;
            powerUpData.price = 4000;
        }
        else if (powerUpData.rarity is 1)
        {
            baseR = 0;
            baseG = 215;
            baseB = 255;
            powerUpData.price = 6000;
        }
        else if (powerUpData.rarity is 2)
        {
            baseR = 170;
            baseG = 0;
            baseB = 255;
            powerUpData.price = 9000;
        }
        else if (powerUpData.rarity is 3)
        {
            baseR = 255;
            baseG = 170;
            baseB = 0;
            powerUpData.price = 13000;

        }
        PriceText.text = new string("$" + powerUpData.price);
        CanBuyParts.startColor = new Color32(baseR, baseG, baseB, 20);
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
        }

    }
    private void OnMouseExit()
    {
        CanBuyParts.startLifetime = .5f;
        CanBuyParts.startColor = new Color32(baseR, baseG, baseB, 100);
    }
    //-----------------------------
    //purchase effects
    private void OnMouseDown()
    {
        if (ConnectionManager.CURRENTscore >= powerUpData.price)
        {
            ConnectionManager.AddPowerUp(powerUpData.name);
            Sold = true;
            CanBuyParts.Stop();
            PartsPlaying = false;
            PriceText.text = "SOLD";

            #region
            //The upgrade traits
            //Globalstats.Atkspeed = (Globalstats.Atkspeed + AtkSpeedAdded) * AtkSpeedMult;
            //Globalstats.Damage = (Globalstats.Damage + DamageAdded) * DamageMult;
            //Globalstats.Speed = (Globalstats.Speed + SpeedAdded);
            //Globalstats.Range = Globalstats.Range + RangeAdded;
            ////-----------------------------
            ////applies Special upgrade tags
            //if (SpecialUpgrade is 1)
            //{
            //    Globalstats.SpecialUp1 = true;
            //}
            //else if (SpecialUpgrade is 2)
            //{
            //    Globalstats.SpecialUp2 = true;
            //}
            //else if (SpecialUpgrade is 3)
            //{
            //    Globalstats.SpecialUp3 = true;
            //}
            //else if (SpecialUpgrade is 4)
            //{
            //    Globalstats.SpecialUp4 = true;
            //}
            //-----------------------------
            #endregion

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
