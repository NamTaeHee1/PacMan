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

    public bool isHaveThisColor = false;
    public bool isSelectThisColor = false;

    private void Awake()
    {
        if (!isHaveThisColor)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(CharacterColor.r, CharacterColor.g, CharacterColor.b, 70);
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = new Color32(TextColor.r, TextColor.g, TextColor.b, 70);
        }
        else
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = CharacterColor;
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = TextColor;
        }
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = ColorText;
    }

    public void TurnOnOff(bool isON)
    {

    }

}