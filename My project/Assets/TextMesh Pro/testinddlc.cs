using UnityEngine;

public class testinddlc : MonoBehaviour
{
    public ParticleSystem particleSystem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            particleSystem.Play();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            particleSystem.Pause();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            particleSystem.Stop();
        }
    }
}
