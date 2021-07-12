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

        private void SelectButtonStateCheck()
        {
            StoreSelectButton.SetActive(StoreManager.CharacterColorList[CharacterColorScrollSnap.CurrentPanel].ColorName.Equals(StoreManager.CharacterColor.ColorName));
            StoreSelectButtonText.text = StoreManager.CharacterColorList[CharacterColorScrollSnap.CurrentPanel].isHaveThisColor ? "º±≈√" : StoreManager.CharacterColorList[CharacterColorScrollSnap.CurrentPanel].NecessaryElectronic.ToString();
        }
    }
}