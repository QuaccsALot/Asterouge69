using System.Linq.Expressions;
using UnityEngine;

public class AstroidLocalObj : MonoBehaviour
{
    public float speed = 15f;
    public float speedRandomization = 5f;
    public float positionRandomization = 50f;


    public GameObject prefab;




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






        public void OnTriggerEnter2D(Collider2D other)
        {

            if (other.CompareTag("Bullet"))
            {

            try
            {
                GameObject var = Instantiate(prefab, transform.position, Quaternion.identity);

                AstroidLocalObj var2 = var.GetComponent<AstroidLocalObj>();

                var2.speed = 3f;

                var2.setAstroid();



                GameObject var3 = Instantiate(prefab, transform.position, Quaternion.identity);

                AstroidLocalObj var4 = var.GetComponent<AstroidLocalObj>();

                var4.speed = 3f;

                var4.setAstroid();
            } catch { }





            gameObject.SetActive(false);

            }

        }





}
