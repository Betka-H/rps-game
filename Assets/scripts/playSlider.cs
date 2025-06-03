using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class playSlider : MonoBehaviour
{
    public TMP_Text txtDisp;

    void Start()
    {
        UpdateSliderValue(GetComponent<Slider>().value);
    }

    public void UpdateSliderValue(float value)
    {
        txtDisp.text = value.ToString();
    }
}
