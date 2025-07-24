using UnityEngine;

public class uhmAlwaysOn : MonoBehaviour
{
    public ConnectionManager connectionManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        connectionManager = GameObject.Find("ConnectionManager").GetComponent<ConnectionManager>();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        try
        {
            connectionManager.enabled = true;
            connectionManager.gameObject.SetActive(true);
        }
        catch { }

    }
}
