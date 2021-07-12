using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorInfo : MonoBehaviour
{
    private SpriteRenderer CharacterColorImage;
    private TextMeshPro CharacterColorText;

    public bool isHaveThisColor = false;
    public bool isSelectThisColor = false;

    private void Awake()
    {
        CharacterColorImage = transform.GetChild(0).GetComponent<SpriteRenderer>();
        CharacterColorText = transform.GetChild(1).GetComponent<TextMeshPro>();
    }

    public Color32 CharacterColor { 
        get { 
            return CharacterColorImage.color; 
        }
    }
    
    public string ColorName {
        get {
            return CharacterColorText.text;
        }
    }
}