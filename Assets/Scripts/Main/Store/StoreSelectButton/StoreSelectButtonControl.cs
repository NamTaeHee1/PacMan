using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DanielLochner.Assets.SimpleScrollSnap {
    public class StoreSelectButtonControl : MonoBehaviour
    {
        [SerializeField] private SimpleScrollSnap CharacterColorScrollSnap;

        [SerializeField] private GameObject StoreSelectButton;

        [SerializeField] private TextMeshProUGUI StoreSelectButtonText;

        private void Start() => SelectButtonStateCheck();

        public void SelectButtonStateCheck()
        {
            StoreSelectButton.gameObject.SetActive(!StoreManager.CharacterColorList[CharacterColorScrollSnap.CurrentPanel].isSelectThisColor);
            StoreSelectButtonText.text = StoreManager.CharacterColorList[CharacterColorScrollSnap.CurrentPanel].isHaveThisColor ? "º±≈√" : StoreManager.CharacterColorList[CharacterColorScrollSnap.CurrentPanel].NecessaryPoint.ToString();
        }

        public void SelectThisColor()
        {
            ColorInfo CurrentColorInfo = StoreManager.CharacterColorList[CharacterColorScrollSnap.CurrentPanel];

            if (!CurrentColorInfo.isHaveThisColor)
                CurrentColorInfo.BuyColor();
            else
            {
                StoreManager.CharacterColor.TurnOnOff(false);
                StoreManager.CharacterColor = CurrentColorInfo;
                StoreManager.CharacterColor.TurnOnOff(true);
            }
            SelectButtonStateCheck();
            FindObjectOfType<StoreManager>().ReloadPointMoney();
        }
    }
}