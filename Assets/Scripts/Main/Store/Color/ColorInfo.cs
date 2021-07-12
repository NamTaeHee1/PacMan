using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorInfo : MonoBehaviour
{
    public Color32 SpriteColor;
    public Color32 TextColor;

    public string ColorText;

    public int NecessaryPoint;

    private SpriteRenderer ColorSpriteRenderer;

    private TextMeshProUGUI ColorTextMeshPro;

    public bool isHaveThisColor = false;
    public bool isSelectThisColor = false;

    private void Awake()
    {
        ColorSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        ColorTextMeshPro = transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        if (!isHaveThisColor)
        {
            ColorSpriteRenderer.color = new Color32(SpriteColor.r, SpriteColor.g, SpriteColor.b, 70);
            ColorTextMeshPro.color = new Color32(TextColor.r, TextColor.g, TextColor.b, 70);
        }
        else
        {
            ColorSpriteRenderer.color = SpriteColor;
            ColorTextMeshPro.color = TextColor;
        }
        ColorTextMeshPro.text = ColorText;
    }

    public void TurnOnOff(bool isON)
    {
        SpriteColor.a = isON ? (byte)255 : (byte)70;
        TextColor.a = isON ? (byte)255 : (byte)70;

        ColorSpriteRenderer.color = SpriteColor;
        ColorTextMeshPro.color = TextColor;

        isSelectThisColor = isON;
    }

    public void BuyColor()
    {
        int Money = DanielLochner.Assets.SimpleScrollSnap.StoreManager.PointMoeny;

        if(Money >= NecessaryPoint)
        {
            DanielLochner.Assets.SimpleScrollSnap.StoreManager.PointMoeny -= this.NecessaryPoint;
            isHaveThisColor = true;
        }
    }

}