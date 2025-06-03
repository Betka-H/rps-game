using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class button : MonoBehaviour
{
    [Header("text obj")]
    public TextMeshProUGUI textMeshProUGUI;

    [Header("colors")]
    public Color normalColor, hoverColor, activateColor;

    Vector3 originalScale;

    [Header("events")]
    public UnityEvent onClickEvents; // on regular click
    public UnityEvent altClickEvents; // on shift-click

    bool isPressed = false;

    void Awake()
    {
        originalScale = gameObject.transform.localScale;
    }
    void OnValidate()
    {
        textMeshProUGUI.color = normalColor;
    }
    void OnEnable()
    {
        OnMouseExit();
    }
    void OnDisable()
    {
        OnMouseUp();
    }

    void OnMouseEnter()
    {
        // change color
        if (isPressed)
            textMeshProUGUI.color = activateColor;
        else textMeshProUGUI.color = hoverColor;

        // change scale
        transform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
    }
    void OnMouseExit()
    {
        // change color
        textMeshProUGUI.color = normalColor;

        // change scale
        transform.localScale = originalScale;
    }

    void OnMouseDown()
    {
        // change color
        textMeshProUGUI.color = activateColor;

        isPressed = true;
    }
    void OnMouseUpAsButton() // OnMouseUpAsButton is only called when the mouse is released over the same Collider as it was pressed.
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit)
        && hit.transform == transform)
        {
            // change color
            textMeshProUGUI.color = hoverColor;

            // invoke events
            if (Input.GetKey(KeyCode.LeftShift) && altClickEvents.GetPersistentEventCount() != 0)
            {
                Debug.Log($"alt invoke");
                altClickEvents.Invoke();
            }
            else onClickEvents.Invoke();
        }
    }
    void OnMouseUp()
    {
        isPressed = false;
    }
}
