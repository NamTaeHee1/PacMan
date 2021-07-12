using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorInfo : MonoBehaviour
{
    public Color32 CharacterColor;
    public string ColorText;
    public int NecessaryElectronic;

    public bool isHaveThisColor = false;
    public bool isSelectThisColor = false;

    private void Awake()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = CharacterColor;
        transform.GetChild(1).GetComponent<TextMeshPro>().text = ColorText;
    }

}