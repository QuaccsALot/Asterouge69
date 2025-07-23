using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
    public Sprite noMovemenModel;
    public Sprite movementModel1;
    public Sprite movementModel2;

    public float timeToSwitch;


    public SpriteRenderer playerModel;
    public string state = "no move"; //no move, move1, move2
    public float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerModel = GameObject.Find("Player Model").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (state == "no move")
            {
                state = "move1";
            }
        }
        


        if (!Input.GetKey(KeyCode.W))
        {
            if (!Input.GetKey(KeyCode.UpArrow))
            {
                state = "no move";
                playerModel.sprite = noMovemenModel;

                timer = 0f;
            }
        }




        if (state == "move1")
        {
            timer += Time.deltaTime;

            if (timer >= timeToSwitch)
            {
                state = "move2";
                playerModel.sprite = movementModel2;

                timer = 0f;
            }
        }


        if (state == "move2")
        {
            timer += Time.deltaTime;

            if (timer >= timeToSwitch)
            {
                state = "move1";
                playerModel.sprite = movementModel1;
                timer = 0f;
            }
        }




    }
}
