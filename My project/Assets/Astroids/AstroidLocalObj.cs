using System.Linq.Expressions;
using System.Threading;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class AstroidLocalObj : MonoBehaviour
{
    public float speed = 15f;
    public float speedRandomization = 5f;
    public float positionRandomization = 50f;

    public float randomSize;


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

        randomSize /= 2;
    }


    void Update()    
    {


        // Step 3: Move forward toward center
        transform.Translate(Vector3.up * speed * Time.deltaTime);





    }



    void newFunc()
    {
        if (gameObject.name == "big boi(Clone)")
        {
            // ger.numba += 20;
            ConnectionManager.CURRENTscore += 20;
            print("test");
        }
        if (gameObject.name == "medium boi(Clone)")
        {
            // ger.numba += 30;
            ConnectionManager.AddScore(30);
            print("test2");
        }
        if (gameObject.name == "small boi(Clone)")
        {
            // ger.numba += 40;
            ConnectionManager.AddScore(40);
            print("test3");


            GameObject yur = GameObject.Find("AstroidMaker");
            AstroidMakerScript yur2 = yur.GetComponent<AstroidMakerScript>();
            yur2.count += 1;
        }
        
    }





        public void OnTriggerEnter2D(Collider2D other)
        {

            if (other.CompareTag("Bullet"))
            {
            newFunc();


            try
            {

                for (int i = 0; i < 2; i++)
                {
                    GameObject newAstroid = Instantiate(prefab, transform.position, Quaternion.identity);

                    AstroidLocalObj scripts = newAstroid.GetComponent<AstroidLocalObj>();

                    scripts.speed = 3f;

                    scripts.setAstroid();



                    float randomScale = (Random.Range(-randomSize, randomSize) / 100) + 1;
                    newAstroid.transform.localScale = new Vector3(newAstroid.transform.localScale.x * randomScale,
                                                                newAstroid.transform.localScale.y * randomScale,
                                                                newAstroid.transform.localScale.z * randomScale);

                    
                }
            } catch { }





            Destroy(gameObject);

            }
            











        }





}
