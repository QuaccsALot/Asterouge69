using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed * 100f;



    }







    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Astroid"))
        {
            gameObject.SetActive(false);
        }



    }
}
