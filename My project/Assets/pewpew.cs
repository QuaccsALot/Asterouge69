using UnityEngine;

public class pewpew : MonoBehaviour

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject player;
    public GameObject prefab;


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
}
