using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DanielLochner.Assets.SimpleScrollSnap {
    public class SelectButtonControl : MonoBehaviour
    {
        [SerializeField] private SimpleScrollSnap CharacterColorScrollSnap;

        public void ColorPanelChange()
        {
            gameObject.SetActive(StoreManager.CharacterColorList[CharacterColorScrollSnap.CurrentPanel].ColorName.Equals(StoreManager.CharacterColor.ColorName));
        }
    }
}