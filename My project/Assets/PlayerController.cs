using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D physicsHAII;

    public float force = 10; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        physicsHAII = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -Time.deltaTime * 41);
        }





        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, Time.deltaTime * 41);
        }







        if (Input.GetKey(KeyCode.UpArrow))
        {
            physicsHAII.AddForce(transform.up * force);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            physicsHAII.AddForce(transform.up *  -force);
        }
    }






    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Astroid"))
        {
            Destroy(gameObject);
        }
    }
}
