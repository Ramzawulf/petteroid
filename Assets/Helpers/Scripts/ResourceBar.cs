using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ResourceBar : MonoBehaviour
{

    public Image Foreground;
    public Image Background;
    public Text Label;

    public string BarName = "";

    public float CurrentValue = 1;
    public float MaxValue = 1;

    void Start()
    {
        gameObject.name = BarName;
    }

    void Update()
    {
        Foreground.fillAmount = CurrentValue / MaxValue;
        Label.text = string.Format(BarName + " {0}/{1}", CurrentValue, MaxValue);
    }
}
