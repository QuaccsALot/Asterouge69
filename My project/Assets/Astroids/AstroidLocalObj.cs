using UnityEngine;

public class AstroidLocalObj : MonoBehaviour
{
    public float speed = 15f;
    public float speedRandomization = 5f;
    public float positionRandomization = 50f;

    public void setAstroid()
    {
        if (speed == 0)
        {
            speed = 15 + Random.Range(-speedRandomization, speedRandomization);
        }



        Vector3 randomPosition = new Vector3(Random.Range(-positionRandomization, positionRandomization),
                                            Random.Range(-positionRandomization, positionRandomization),
                                            0);

        // Step 1: Get direction to (0, 0)
        Vector3 direction = (randomPosition - transform.position).normalized;

        // Step 2: Rotate to face that direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }


    void Start()
    {
        setAstroid();
    }


    void Update()
    {


        // Step 3: Move forward toward center
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
