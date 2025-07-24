using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.SceneManagement;
using UnityEditor.MemoryProfiler;
using UnityEditor.PackageManager.Requests;


[System.Serializable]
public class powerUp
{
    [Header("General (can touch)")]
    public string name = "";
    public byte rarity = 0; //common, uncommon, rare, legend
    public string shownName;
    public string summary;

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
    public List<powerUp> EXPO_CURRENTpowerUps = new List<powerUp>();

    [Header("(NO TOUCHY DURING GP) Exposed Statics - dictionary")]
    public List<powerUp> EXPO_powerUpDictionary = new List<powerUp>();


    [Header("Debug stuffs")]
    public bool shotgunTesting = false;

    public bool sniperTesting = false;

    public bool bombTesting = false;

    public bool breakTesting = false;

    //[Header("(NO TOUCHY DURING GP) Exposed Statics - current")]






    

    [Header("Statics")] //NotShown!
    public static List<powerUp> powerUpDictionary = new List<powerUp>();
    public static List<powerUp> CURRENTpowerUps = new List<powerUp>();
    public static int CURRENTscore;
    public static List<powerUp> needToInitializePowerUps = new List<powerUp>();


    [Header("Extra stuffs lmao")] //Not Shown!
    public static int ADDpierce = 0;
    public static float lifetimeMult = 1;
    public static float scaleMult = 1;
    public static float SpeedMult = 1;

    private pewpew pewpewRef;

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



        // if (instance.EXPO_CURRENTscore != ConnectionManager.CURRENTscore)
        // {
        //     CURRENTscore = instance.EXPO_CURRENTscore;
        // }









        // Get all public instance field
        pewpewRef = GameObject.Find("Gun").GetComponent<pewpew>();



        SceneManager.sceneLoaded += OnSceneLoaded;
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

        if (SceneManager.GetActiveScene().name == "GameOver" || SceneManager.GetActiveScene().name == "Main Menu")
        {
            needToInitializePowerUps.Clear();
            CURRENTpowerUps.Clear();

            CURRENTscore = 0;
        }


        if (SceneManager.GetActiveScene().name == "Gameplay" || SceneManager.GetActiveScene().name == "ShopUI2")
        {
            this.enabled = true;
        }



        try
        {
            foreach (var item in CURRENTpowerUps)
            {
                if (item.function_UpdateName != "")
                {
                    GameObject obj = GameObject.Find(item.objectName);
                    print("tried to do UpdateLoop: " + item.function_StartName + " on obj; " + item.objectName);

                    //print("adsfjkl;" + item.function_UpdateName);
                    obj.SendMessage(item.function_UpdateName);
                }
            }
        }
        catch { }



        




        



        #region Cheats

        if (shotgunTesting)
        {
            ConnectionManager.AddPowerUp("shotgun");
            shotgunTesting = false;

            OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
        }

        if (sniperTesting)
        {
            ConnectionManager.AddPowerUp("sniper");
            sniperTesting = false;

            OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
        }

        if (bombTesting)
        {
            ConnectionManager.AddPowerUp("bomb");
            bombTesting = false;

            OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
        }


        if (breakTesting)
        {
            ConnectionManager.AddPowerUp("break");
            breakTesting = false;

            OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
        }



        #endregion
    }





    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////





    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        print("ima gummy bear");


        if (scene.name == "GameOver" || scene.name == "Main Menus")
        {
            CURRENTpowerUps.Clear();
            CURRENTscore = 0;
            needToInitializePowerUps.Clear();


            return;
        }







        Debug.Log("Scene changed to: " + scene.name);
        if (scene.name != "Gameplay")
        {

            return;
        }







        if (scene.name == "Gameplay")
        {
            pewpewRef = GameObject.Find("Gun").GetComponent<pewpew>();
        }

        print("its fan");


        try
            {
                foreach (var item in needToInitializePowerUps)
                {
                    if (item.function_StartName != "")
                    {
                        GameObject obj = GameObject.Find(item.objectName);
                        print(obj.transform.name);

                        obj.SendMessage(item.function_StartName);

                        print("Initialized: " + obj.name + " ability");
                    }
                }
            }
            catch { }





        try
        {
            foreach (var item in CURRENTpowerUps)
            {
                if (item.function_StartName != "")
                {
                    GameObject obj = GameObject.Find(item.objectName);
                    print(obj.transform.name);

                    obj.SendMessage(item.function_StartName);

                    print("Initialized: " + obj.name + " ability");
                }
            }
        }
        catch { }
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

        print(new_powerUpData.name);
    }




    public static void AddScore(int deltaScore)
    {
        ConnectionManager.CURRENTscore += deltaScore;
    }



    public static void SubtractScore(int deltaScore)
    {
        ConnectionManager.CURRENTscore -= deltaScore;
    }



    public static powerUp GetRandom__AbilData()
    {
        return powerUpDictionary[Random.Range(0, powerUpDictionary.Count - 1)];
    }




    public static powerUp GetRandomAbilOfRarity(int rarity)
    {
        List<powerUp> name = new List<powerUp>();

        foreach (var item in powerUpDictionary)
        {
            if (item.rarity == rarity)
            {
                name.Add(item);
            }
        }

        return name[Random.Range(0, name.Count)];
    }
}
