using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DanielLochner.Assets.SimpleScrollSnap
{
    public class StoreManager : MonoBehaviour
    {
        public static int PointMoeny = 3000;
        int SelectedPanelIndex = 0;

        [SerializeField] private GameObject CharacterColorContent;


        [SerializeField] private TextMeshProUGUI PointMoneyText;

        private void Awake()
        {
            CharacterColorListUpdate();
            ReloadPointMoney();
        }

        private void Start()
        {
            CharacterColor = CharacterColorContent.transform.GetChild(0).GetComponent<ColorInfo>();
        }


        public static List<ColorInfo> CharacterColorList = new List<ColorInfo>();
        public static ColorInfo CharacterColor;

        [SerializeField] private SimpleScrollSnap CharacterSimpleScrollSnap;

        private void CharacterColorListUpdate()
        {
            CharacterColorList.Clear();
            for (int i = 0; i < CharacterColorContent.transform.childCount; i++)
                CharacterColorList.Add(CharacterColorContent.transform.GetChild(i).GetComponent<ColorInfo>());
        }

        public void CharacterScrollSnapUpdate()
        {
            for (int i = 0; i < CharacterColorContent.transform.childCount; i++)
            {
                if (CharacterColorContent.transform.GetChild(i).GetComponent<ColorInfo>().isSelectThisColor)
                {
                    SelectedPanelIndex = i;
                    break;
                }
            }
            CharacterSimpleScrollSnap.GoToPanel(SelectedPanelIndex);
        }


        public void ReloadPointMoney()
        {
            PointMoneyText.text = string.Format("Point : {0}", PointMoeny.ToString());
        }
    }
}