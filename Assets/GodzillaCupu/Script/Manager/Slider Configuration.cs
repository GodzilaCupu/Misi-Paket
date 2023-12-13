using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GodzillaCupu.Manager
{
    public class SliderConfiguration : MonoBehaviour
    {
        [SerializeField] private string id;
        public string ID
        {
            get => id;
            set => id = value;
        }
        
        public IconSettings iconSettings;
        public SliderSettings sliderSettings;
        public float SliderValue() => sliderSettings.value;

        private void Start()
        {
            if (id == string.Empty || id == "")
                Debug.LogError($"[ID SLIDER] id from {gameObject.name} is empty, check Again");
            
            this.gameObject.name = id + " Slider";
            iconSettings.SetIcon(
                iconSettings._object,
                iconSettings.haveIcon,
                iconSettings.image,
                iconSettings.color
            );
            
            sliderSettings.SetHandle(
                sliderSettings.sliderObject,
                sliderSettings.haveHandle,
                sliderSettings.baseColorBackground,
                sliderSettings.selectedColorBackground,
                sliderSettings.spriteHandle,
                sliderSettings.colorHandle
            );
        }

        [Serializable]
        public class IconSettings
        {
            public bool haveIcon;
            public GameObject _object;
            public Sprite image;
            public Color color;

            public void SetIcon(
                GameObject obj,
                bool haveIcon = true,
                Sprite img = null,
                Color color = default(Color)
            )
            {
                Image _img = obj.GetComponent<Image>();
                _img.sprite = img == null ? _img.sprite : img;
                _img.color = color == null ? _img.color : color;

                obj.SetActive(haveIcon);
            }
        }

        [Serializable]
        public class SliderSettings
        {
            public GameObject sliderObject;
            public Slider slider => sliderObject.GetComponent<Slider>();
            public float value { get => slider.value; }

            [Header("Slider Background")]
            public Color baseColorBackground;
            public Color selectedColorBackground;

            [Header("Handle")]
            public bool haveHandle;
            public Sprite spriteHandle;
            public Color colorHandle;

            public void SetHandle(
                GameObject obj,
                bool haveHandle,
                Color baseFillColor = default(Color),
                Color selectedFillColor = default(Color),
                Sprite spriteHandle = null,
                Color colorHandle = default(Color)
            )
            {
                Slider _slider = obj.GetComponent<Slider>();

                // Fill Slider Element
                GameObject _baseFill = _slider.transform.GetChild(0).gameObject;
                GameObject _selectedFill = _slider.fillRect.gameObject;

                Color _baseFillColor = _baseFill.GetComponent<Image>().color;
                _baseFillColor = baseFillColor == default(Color) ? _baseFillColor : baseFillColor;

                Color _selectedFillColor = _selectedFill.GetComponent<Image>().color;
                _selectedFillColor =
                    selectedFillColor == default(Color) ? _selectedFillColor : selectedFillColor;

                // Handle Slider Element
                GameObject _handleSlider = _slider.handleRect.gameObject;

                Image _handleImage = _handleSlider.GetComponent<Image>();
                _handleImage.sprite = spriteHandle == null ? _handleImage.sprite : spriteHandle;
                _handleImage.color =
                    colorHandle == default(Color) ? _handleImage.color : colorHandle;
            }
        }

    }
}
