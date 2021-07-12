using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorInfo : MonoBehaviour
{
    public Color32 CharacterColor;
    public Color32 TextColor;

    public string ColorText;

    public int NecessaryElectronic;

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
            ColorSpriteRenderer.color = new Color32(CharacterColor.r, CharacterColor.g, CharacterColor.b, 70);
            ColorTextMeshPro.color = new Color32(TextColor.r, TextColor.g, TextColor.b, 70);
        }
        else
        {
            ColorSpriteRenderer.color = CharacterColor;
            ColorTextMeshPro.color = TextColor;
        }
        ColorTextMeshPro.text = ColorText;
    }

    public void TurnOnOff(bool isON)
    {
        CharacterColor.a = isON ? (byte)255 : (byte)70;
        TextColor.a = isON ? (byte)255 : (byte)70;

        ColorSpriteRenderer.color = CharacterColor;
        ColorTextMeshPro.color = TextColor;

        isSelectThisColor = isON;
    }

    public void BuyColor(ColorInfo Color)
    {

    }

}