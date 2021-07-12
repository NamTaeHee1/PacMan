using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorInfo : MonoBehaviour
{
    private SpriteRenderer CharacterColorImage;

    public bool isHaveThisColor = false;
    public bool isSelectThisColor = false;

    private void Awake()
    {
        CharacterColorImage = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    public Color32 CharacterColor { 
        get { 
            return CharacterColorImage.color; 
        }
    }
}