using System.Collections.Generic;
using UnityEngine;

public class pewpew : MonoBehaviour

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject player;
    public GameObject prefab;

    public List<string> modifiers;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newnew = Instantiate(prefab, transform.position, Quaternion.identity);



            // Step 1: Get direction to (0, 0)
            Vector3 direction = (transform.position - player.transform.position).normalized;

            // Step 2: Rotate to face that direction
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            newnew.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        }
    }














    //////////////////////////////////////////////////////////////////////////////////////////////////////




    void CM_shotgunUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newnew = Instantiate(prefab, transform.position, Quaternion.identity);



            // Step 1: Get direction to (0, 0)
            Vector3 direction = (transform.position - player.transform.position).normalized;

            // Step 2: Rotate to face that direction
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f + 30;
            newnew.transform.rotation = Quaternion.Euler(0f, 0f, angle);












            GameObject newnewnew = Instantiate(prefab, transform.position, Quaternion.identity);

            // Step 2: Rotate to face that direction
            float other_angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f - 30;
            newnewnew.transform.rotation = Quaternion.Euler(0f, 0f, other_angle);
        }
    }
}
