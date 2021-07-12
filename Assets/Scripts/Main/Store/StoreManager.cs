using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DanielLochner.Assets.SimpleScrollSnap
{
    public class StoreManager : MonoBehaviour
    {
        public int PointMoeny = 0;

        [SerializeField] private GameObject CharacterColorContent;

        public static List<ColorInfo> CharacterColorList = new List<ColorInfo>();
        public static ColorInfo CharacterColor;

        [SerializeField] private SimpleScrollSnap CharacterSimpleScrollSnap;

        private void Awake()
        {
            CharacterColorListUpdate();
        }

        private void Start()
        {
            CharacterColor = CharacterColorContent.transform.GetChild(0).GetComponent<ColorInfo>();
        }

        private void CharacterColorListUpdate()
        {
            CharacterColorList.Clear();
            for (int i = 0; i < CharacterColorContent.transform.childCount; i++)
                CharacterColorList.Add(CharacterColorContent.transform.GetChild(i).GetComponent<ColorInfo>());
        }

        public void CharacterScrollSnapUpdate()
        {
            int SelectedPanelIndex = 0;
            for (int i = 0; i < CharacterColorContent.transform.childCount; i++)
            {
                if (CharacterColorContent.transform.GetChild(i).GetComponent<ColorInfo>().isSelectThisColor)
                    SelectedPanelIndex = i;
            }
        }
    }
}