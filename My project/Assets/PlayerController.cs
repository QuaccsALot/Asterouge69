using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    public float turnSpeed = 327f;
    public float forwardForce = 5f;
    public float maxSpeed = 5f;

    public float velocityThreshold = 6f;
    public float normalDamping = 5f;
    public float highDamping = 3f;


    [Header("Debug")]
    public Rigidbody2D _rb;
    public Vector2 worldVelocity;
    public bool ResetEverything = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.linearDamping = normalDamping;
    }





    // Update is called once per frame
    void Update()
    {









        float speed = _rb.linearVelocity.magnitude;

        if (speed > velocityThreshold)
        {
            _rb.linearDamping = highDamping;
        }
        else
        {
            _rb.linearDamping = normalDamping;
        }





            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, 0, -Time.deltaTime * turnSpeed);
            }





        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, Time.deltaTime * turnSpeed);
        }






        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector2 localForward = transform.up;
            localForward *= forwardForce;

                worldVelocity.x += localForward.x * Time.deltaTime;
                worldVelocity.y += localForward.y * Time.deltaTime;
        }


        //worldVelocity = Vector2.ClampMagnitude(worldVelocity, maxSpeed); //clamp MaxSpeed


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
        if (other.CompareTag("Astroid"))
        {
            gameObject.SetActive(false);
        }

        

    }

}
