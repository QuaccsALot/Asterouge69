using UnityEngine;

public class GC_Stuffs : MonoBehaviour
{
    public int side = 0;
        //Up, Right, Down, Left

    public float distX = 11.5f;
    public float distY = 7.5f;

    public Vector2 DistAdded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DistAdded = Vector2.zero;

        switch (side)
        {
            case 0:
                DistAdded = new Vector2(0, -2 * distY);
                break;
            case 1:
                DistAdded = new Vector2(-2 * distX, 0);
                break;
            case 2:
                DistAdded = new Vector2(0, 2 * distY);
                break;
            case 3:
                DistAdded = new Vector2(2 * distX, 0);
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }






    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GarbageCollector")) return;





        print("uiqewrpuioqerwuioprqewuioperw");

        Vector3 newPos = other.transform.position;
            newPos.x += DistAdded.x;
            newPos.y += DistAdded.y;

        other.transform.position = newPos;




        if (other.TryGetComponent<AstroidLocalObj>(out AstroidLocalObj component))
        {
            component.setAstroid();
        } 
        
        else


        if (other.TryGetComponent<Rigidbody2D>(out Rigidbody2D _rb))
        {
            Vector2 vel = _rb.linearVelocity;
            vel.x *= -1;
            vel.y *= -1;

            newPos.x += vel.x;
        }
    }
}
