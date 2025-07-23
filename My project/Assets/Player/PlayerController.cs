using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    public float turnSpeed = 327f;
    public float forwardForce = 5f;
    public float maxSpeed = 5f;





    [Header("Debug")]
    public GameObject model;
    public Rigidbody2D _rb;
    public Vector2 worldVelocity;
    public bool ResetEverything = false;
    public bool invinsible = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        model = GameObject.Find("Player Model");
    }





    // Update is called once per frame
    void Update()
    {




            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, 0, -Time.deltaTime * turnSpeed);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, 0, -Time.deltaTime * turnSpeed);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, 0, Time.deltaTime * turnSpeed);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, 0, Time.deltaTime * turnSpeed);
            }






        if (Input.GetKey(KeyCode.W))
        {
            Vector2 localForward = transform.up;
            localForward *= forwardForce;

                worldVelocity.x += localForward.x * Time.deltaTime;
                worldVelocity.y += localForward.y * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector2 localForward = transform.up;
            localForward *= forwardForce;

                worldVelocity.x += localForward.x * Time.deltaTime;
                worldVelocity.y += localForward.y * Time.deltaTime;
        }






        // Clamp the speed
        worldVelocity = Vector2.ClampMagnitude(worldVelocity, maxSpeed);

        // If not accelerating, apply damping
        if (!Input.GetKey(KeyCode.W))
        {
            worldVelocity = Vector2.Lerp(worldVelocity, Vector2.zero, Time.deltaTime * 1.5f); // "0f" controls speed of slowdown
        }
        if(!Input.GetKey(KeyCode.UpArrow))
        {
            worldVelocity = Vector2.Lerp(worldVelocity, Vector2.zero, Time.deltaTime * 1.5f); // "0f" controls speed of slowdown
        }

        // Apply the velocity to the Rigidbody
        _rb.linearVelocity = worldVelocity;




        if (ResetEverything)
        {
            transform.position = Vector3.zero;
            _rb.linearVelocity = Vector3.zero;

            worldVelocity = Vector3.zero;
            ResetEverything = false;

        }
    }






    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Astroid") && !invinsible)
        {
            gameObject.SetActive(false);
        }

    }

}
