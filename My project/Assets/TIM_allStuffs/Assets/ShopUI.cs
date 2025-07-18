using TMPro;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ShopUI : MonoBehaviour
{
    private GameObject Test_Item;
    private int temprarity = 1;
    public float Points = 9999999;
    public float Damage = 10;
    public float Speed = 10;
    public float Atkspeed = 10;
    public float Range = 10;
    public bool SpecialUp1 = false;
    public bool SpecialUp2 = false;
    public bool SpecialUp3 = false;
    public bool SpecialUp4 = false;

    void Start()
    {
        
        Test_Item = transform.Find("Test Item").gameObject;
        Test_Item.SetActive(false);
        for (int i = 0; i < 6;)
        {
            temprarity = Random.Range(0, 16);
            GameObject Testitemclone = Instantiate(Test_Item, new Vector3((Mathf.Floor(i * .5f)) * 2+2, (i % 2)*3, 0), Quaternion.Euler(0, 0, 0));
            Testitemclone.SetActive(true);
            Purchaseable cloneScript = Testitemclone.GetComponent<Purchaseable>();
            Testitemclone.transform.parent = this.transform;
            if (temprarity <= 9)
            {
                cloneScript.Rareity = 0;
            }
            else if (temprarity <= 13)
            {
                cloneScript.Rareity = 1;
            }
            else if (temprarity <= 15)
            {
                cloneScript.Rareity = 2;
            }
            else
            {
                cloneScript.Rareity = 3;
            }
            i = i + 1;
        }
    }
    // Update is called once per frame
    void Update()
    {


    }
}
