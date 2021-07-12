using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public static StoreManager Instance;

    public int PointMoeny = 0;

    [SerializeField] private GameObject CharacterColorContent;

    public static List<ColorInfo> CharacterColorList;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        CharacterColorListUpdate();
    }

    private void CharacterColorListUpdate()
    {
        CharacterColorList.Clear();
        for (int i = 0; i < CharacterColorContent.transform.childCount; i++)
            CharacterColorList.Add(CharacterColorContent.transform.GetChild(i).GetComponent<ColorInfo>());
    }
}
