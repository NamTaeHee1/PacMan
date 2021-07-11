using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ColorInfo : ScriptableObject
{
    [SerializeField] private Color32 CharacterColor;
    [SerializeField] private string ColorName;
}