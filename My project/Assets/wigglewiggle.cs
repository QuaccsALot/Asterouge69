
using UnityEngine;


public class WiggleWiggle: MonoBehaviour
{
    //-----------------------------
    //def global vars
    //replace Temp Vars with Real Var


    [Header("private stuffs")] //not shown
    private float jiggleReducerStarter = 0;
    private float ExpandedSizeStarter = 0;
    private float basesizeXStarter = 0;
    private float basesizeYStarter = 0;
    //---------------------------------------------------------Start down
    void Start()
    {
        basesizeXStarter = transform.localScale.x;
        basesizeYStarter = transform.localScale.y;
    }
    //---------------------------------------------------------Start up
    //effects when hover over
    void OnMouseOver()
    {
        
            jiggleReducerStarter = jiggleReducerStarter + 10;
            ExpandedSizeStarter = ExpandedSizeStarter + 1;
        print("hiii");

    }
    //-----------------------------
    //purchase effects
    //---------------------------------------------------------updates down
    void Update()
    {
        //Checks if its purchasable
        //-----------------------------
        //appling hover effects
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * 3) * jiggleReducerStarter / 5);
        transform.localScale = new Vector3(basesizeXStarter + ExpandedSizeStarter / 20, basesizeYStarter + ExpandedSizeStarter / 10);
        if (jiggleReducerStarter >= .5)
        {
            jiggleReducerStarter = jiggleReducerStarter - 1;
        }
        if (jiggleReducerStarter >= 60)
        {
            jiggleReducerStarter = 60;
        }
        if (ExpandedSizeStarter >= 1)
        {
            ExpandedSizeStarter = ExpandedSizeStarter - .5f;
        }
        if (ExpandedSizeStarter >= 10)
        {
            ExpandedSizeStarter = 10;
        }
        //-----------------------------
    }
    //---------------------------------------------------------updates up


}
