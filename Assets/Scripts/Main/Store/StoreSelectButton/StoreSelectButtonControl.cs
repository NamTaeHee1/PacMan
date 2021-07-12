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

        private void Update() => SelectButtonStateCheck();

        public void SelectButtonStateCheck()
        {
            StoreSelectButton.gameObject.SetActive(StoreManager.CharacterColorList[CharacterColorScrollSnap.CurrentPanel].isSelectThisColor);
            StoreSelectButtonText.text = StoreManager.CharacterColorList[CharacterColorScrollSnap.CurrentPanel].isHaveThisColor ? "����" : StoreManager.CharacterColorList[CharacterColorScrollSnap.CurrentPanel].NecessaryElectronic.ToString();
        }
    }
}