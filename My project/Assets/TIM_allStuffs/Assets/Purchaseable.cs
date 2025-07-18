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

public class Purchaseable : MonoBehaviour
{
    //-----------------------------
    //def global vars
    //replace Temp Vars with Real Vars
    [Header("General")]
    public bool Canbuy = false;
    public bool Sold = false;
    [SerializeField, Header("Upgrade Atributes"), Space(20)]
    public float DamageAdded = 0;
    public float DamageMult = 1;
    public float SpeedAdded = 0;
    public float AtkSpeedMult = 1;
    public float AtkSpeedAdded = 0;
    public float RangeAdded = 0;
    public int SpecialUpgrade = 0;
    public int Rareity = 0;
    public float price = 0;

    private float jiggleReducer = 0;
    private float ExpandedSize = 0;
    private float basesizeX = 0;
    private float basesizeY = 0;
    private byte baseR = 0;
    private byte baseG = 0;
    private byte baseB = 0;
    private TMP_Text PriceText;
    private ParticleSystem CanBuyParts;
    private ShopUI Globalstats;



    //---------------------------------------------------------Start down
    void Start()
    {
        Transform parentTransform = transform.parent;
        Globalstats = parentTransform.GetComponent<ShopUI>();
        PriceText = GetComponentInChildren<TextMeshProUGUI>();
        CanBuyParts = GetComponentInChildren<ParticleSystem>();
        basesizeX = transform.localScale.x;
        basesizeY = transform.localScale.y;

        if (Rareity is 0)
        {
            baseR = 136;
            baseG = 255;
            baseB = 0;
            price = 4000;
        }
        else if (Rareity is 1)
        {
            baseR = 0;
            baseG = 215;
            baseB = 255;
            price = 6000;
        }
        else if (Rareity is 2)
        {
            baseR = 170;
            baseG = 0;
            baseB = 255;
            price = 9000;
        }
        else if (Rareity is 3)
        {
            baseR = 255;
            baseG = 170;
            baseB = 0;
            price = 13000;

        }
        PriceText.text = price.ToString();
        CanBuyParts.startColor = new Color32(baseR, baseG, baseB, 20);
        CanBuyParts.startLifetime = .5f;


    }
    //---------------------------------------------------------Start up
    //effects when hover over
    void OnMouseOver()
    {
        if (Canbuy)
        {
            jiggleReducer = jiggleReducer + 10;
            ExpandedSize = ExpandedSize + 1;
            CanBuyParts.startLifetime = 1;
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
        if (Globalstats.Points >= price)
        {
            Globalstats.Points = Globalstats.Points - price;
            Sold = true;
            CanBuyParts.Stop();
            PriceText.text = "SOLD";

            //The upgrade traits
            Globalstats.Atkspeed = (Globalstats.Atkspeed + AtkSpeedAdded) * AtkSpeedMult;
            Globalstats.Damage = (Globalstats.Damage + DamageAdded) * DamageMult;
            Globalstats.Speed = (Globalstats.Speed + SpeedAdded);
            Globalstats.Range = Globalstats.Range + RangeAdded;
            //-----------------------------
            //applies Special upgrade tags
            if (SpecialUpgrade is 1)
            {
                Globalstats.SpecialUp1 = true;
            }
            else if (SpecialUpgrade is 2)
            {
                Globalstats.SpecialUp2 = true;
            }
            else if (SpecialUpgrade is 3)
            {
                Globalstats.SpecialUp3 = true;
            }
            else if (SpecialUpgrade is 4)
            {
                Globalstats.SpecialUp4 = true;
            }
            //-----------------------------

            print("bought");
        }

    }
    //---------------------------------------------------------updates down
    void Update()
    {
        //Checks if its purchasable
        if (Globalstats.Points >= price)
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
            CanBuyParts.Stop();
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
