using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorInfo : MonoBehaviour
{
    [SerializeField] private Image CharacterColorImage;
    public Color32 CharacterColor { 
        get { 
            return CharacterColorImage.GetComponent<Image>().color; 
        }
    }
}