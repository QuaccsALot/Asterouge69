using UnityEngine;

public class ShipBackAndForth : MonoBehaviour
{
    private float BaseX = 0;
    private float BaseY = 0;
    private float BackAndForthSEED;
    void Start()
    {
        BaseX = transform.position.x;
        BaseY = transform.position.y;
        BackAndForthSEED = Random.Range(1, 100);
    }
    void Update()
    {
        transform.position = new Vector3(BaseX + Mathf.Sin(BackAndForthSEED + Time.time)/5, BaseY);
    }
}
