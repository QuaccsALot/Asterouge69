using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.MemoryProfiler;
using UnityEditor.PackageManager.Requests;


[System.Serializable]
public class powerUp
{
    [Header("General (can touch)")]
    public string name = "";
    public byte rarity = 0; //common, uncommon, rare, legend

    [Header("Function Names (can touch)")]
    public string function_StartName = "";
    public string function_UpdateName = "";
    public string function_EndName = "";
    public string objectName = ""; //USUALLY JohnTheSpaceShipYAA or Gun



    [Header("NO TOUCHY WILL BREAK EVERYTHING LMAO"), Space(20)]
    public int price; //Populated on Startup
}



 







public class ConnectionManager : MonoBehaviour
{
    public static ConnectionManager instance;

    [Header("NO TOUCHY, JUST FOR SHOW")]
    public int EXPO_CURRENTscore = 0;
    public List<powerUp> EXPO_CURRENTpowerUps = new List<powerUp>();

    [Header("(NO TOUCHY DURING GP) Exposed Statics - dictionary"), Space(23)]
    public List<powerUp> EXPO_powerUpDictionary = new List<powerUp>();

    public bool testingFUCKYOU = false;

    //[Header("(NO TOUCHY DURING GP) Exposed Statics - current")]








    [Header("Statics")] //NotShown!
    public static List<powerUp> powerUpDictionary = new List<powerUp>();
    public static List<powerUp> CURRENTpowerUps = new List<powerUp>();
    public static int CURRENTscore = 0;
    public static List<powerUp> needToInitializePowerUps = new List<powerUp>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (ConnectionManager.instance == null)
        {
            ConnectionManager.instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);



        ConnectionManager.powerUpDictionary = instance.EXPO_powerUpDictionary;
        ConnectionManager.CURRENTpowerUps = instance.EXPO_CURRENTpowerUps;



        PopulatePrice();
    }


    public void PopulatePrice()
    {
        for (int i = 0; i < powerUpDictionary.Count; i++)
        {
            switch (powerUpDictionary[i].rarity)
            {
                case 0:
                    powerUpDictionary[i].price = 4000;
                    break;

                case 1:
                    powerUpDictionary[i].price = 6000;
                    break;

                case 2:
                    powerUpDictionary[i].price = 9000;
                    break;

                case 3:
                    powerUpDictionary[i].price = 13000;
                    break;

                default:
                    Debug.LogError("YOOOOOOOO" + powerUpDictionary[i].name + "doesn't have a valid rarity");
                    powerUpDictionary[i].price = -1;
                    break;

            }
        }
    }


    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



    // Update is called once per frame
    void Update()
    {
        if (instance.EXPO_CURRENTscore != ConnectionManager.CURRENTscore)
        {
            CURRENTscore = instance.EXPO_CURRENTscore;
        }

        try
        {
            foreach (var item in CURRENTpowerUps)
            {
                if (item.function_UpdateName != "")
                {
                    GameObject obj = GameObject.Find(item.objectName);
                    obj.SendMessage(item.function_UpdateName);
                }
            }
        }
        catch { }



        if (testingFUCKYOU)
        {
            ConnectionManager.AddPowerUp("shotgun");
            testingFUCKYOU = false;
        }
    }





    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene changed to: " + scene.name);
        if (scene.name != "Gameplay") return;



        foreach (var item in needToInitializePowerUps)
        {
            if (item.function_StartName != "")
            {
                GameObject obj = GameObject.Find(item.objectName);
                obj.SendMessage(item.function_StartName);

                print("Initialized: " + obj.name + " ability");
            }
        }

        needToInitializePowerUps.Clear();
    }





    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




    public static powerUp GetPowerUpData(string searchedName)
    {
        foreach (var item in ConnectionManager.powerUpDictionary)
        {
            if (item.name == searchedName)
            {
                return item;
            }
        }



        Debug.LogError("Can't find the seached name: " + searchedName);
        return null;
    }

    public static void AddPowerUp(string searchedName)
    {
        powerUp new_powerUpData = ConnectionManager.GetPowerUpData(searchedName);

        ConnectionManager.CURRENTpowerUps.Add(new_powerUpData);
        SubtractScore(new_powerUpData.price);

        ConnectionManager.needToInitializePowerUps.Add(new_powerUpData);
    }




    public static void AddScore(int deltaScore)
    {
        ConnectionManager.CURRENTscore += deltaScore;
    }



    public static void SubtractScore(int deltaScore)
    {
        ConnectionManager.CURRENTscore -= deltaScore;
    }
}
