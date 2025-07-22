using UnityEngine;

public class RenderFirst : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.material.renderQueue = 4000;
    }
}
