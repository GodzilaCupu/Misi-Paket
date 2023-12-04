using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TittleConfiguration : MonoBehaviour
{
    [Serializable]
    public class Text_Object
    {
        public TextMeshProUGUI mainText;
        public TextMeshProUGUI shadowText;
    }

    [Serializable]
    public class Text_Settings
    {
        public bool haveShadow;
        public float size;
        public TMP_FontAsset fontAsset;
        public Color mainColor;
        public Color shadowColor;
    }

    [SerializeField] private string id;
    public string ID
    {
        get => id;
        set => id = value;
    }
    public Text_Object _text;
    public Text_Settings _settings;

    void Start()
    {
        if (id == string.Empty || id == "")
            Debug.LogError($"[TITLE {gameObject.name}] ID is Empty, Check ID");
        if (!_settings.haveShadow)
            Debug.Log($"[TITLE {gameObject.name}] {id} Doesn't have Shadow");

        SetText(
            _text.mainText,
            id,
            _settings.size,
            _settings.fontAsset,
            _settings.mainColor,
            true,
            _text.shadowText,
            _settings.shadowColor
        );
    }

    public void SetText(
        TextMeshProUGUI displayText,
        string text,
        float size = 0,
        TMP_FontAsset asset = null,
        Color mainColor = default(Color),
        bool haveShadow = false,
        TextMeshProUGUI displayShadowText = null,
        Color shadowColor = default(Color)
    )
    {
        displayText.text = text;
        displayText.fontSize = size;
        displayText.font = asset;
        displayText.color = mainColor;

        if (!haveShadow)
            return;

        if (displayShadowText == null)
            Debug.LogError($"[SET TEXT {text}] Shadow Text is Empty, Check Again");
        displayShadowText.text = text;
        displayShadowText.fontSize = size;
        displayShadowText.font = asset;
        displayShadowText.color = shadowColor;
    }
}
