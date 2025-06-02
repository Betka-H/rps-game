using UnityEngine;

public class slot : MonoBehaviour
{
    Vector3 originalScale;
    public bool reactive;
    public SpriteRenderer spriteRenderer;
    public Sprite sprite;

    void Awake()
    {
        if (reactive)
            originalScale = gameObject.transform.localScale;
    }

    void OnValidate()
    {
        spriteRenderer.sprite = sprite;
    }

    void OnMouseEnter()
    {
        if (reactive)
            transform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
    }

    void OnMouseExit()
    {
        if (reactive)
            transform.localScale = originalScale;
    }
}
