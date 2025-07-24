using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 1f;
    public float lifeTime = .1f;
    public int pierce = 0;

    public bool unlimitedPierce = false;

    private int pierceCounter = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject,lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;

        




    }







    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Astroid") && !unlimitedPierce && pierceCounter >= pierce)
        {
            Destroy(gameObject);
        }



    }
}
