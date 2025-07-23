using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class Audio : MonoBehaviour
{
    public GameObject prefab;
    [HideInInspector] public static Audio instance;

    public static void playaudio(string text)
    {
        var audioClip = Resources.Load<AudioResource>(text);

        GameObject speaker = Instantiate(instance.prefab);
        AudioSource speaker2 = speaker.GetComponent<AudioSource>();
        speaker2.resource = audioClip;
        speaker2.Play();
    }











    private void Awake() //NO TOUCHY TOUCHY
    {
        if (instance == null)
        {
            instance = this;
        }
        else        
        {

            Destroy(gameObject);
        }
    }




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playaudio("bomb");
        playaudio("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
