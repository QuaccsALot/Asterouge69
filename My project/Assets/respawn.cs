using UnityEngine;

public class respawn : MonoBehaviour
{
    public GameObject player;



    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.C))
        {
            print("respawned");
            player.SetActive(true);
        }

    }
}
