using UnityEngine;
using UnityEngine.UIElements;

public class Bobbing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float BaseX = 0f;
    public float BaseY = 0f;
    public float BaseZ = 0f;
    private float BobSeed = 0;
    void Start()
    {
        BobSeed = Random.Range(1, 100);
        Vector3 position = transform.position;
        BaseY = position.y;
        BaseX = position.x;
        BaseZ = position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(BaseX, Mathf.Sin(Time.time + BobSeed) / 5 + BaseY, BaseZ); ;
    }
}
