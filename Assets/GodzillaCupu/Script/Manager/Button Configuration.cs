using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GodzillaCupu.Manager
{
    public class ButtonConfiguration : MonoBehaviour
    {
        [Serializable]
        public enum AnimationType
        {
            MoveX,
            MoveY,
            MoveLocalX,
            MoveLocalY,
            Scale
        }

        [Serializable]
        public class ImageButton
        {
            public string id;
            public Sprite img;

            public void ChangeImage(GameObject obj, Sprite img)
            {
                Image _img = obj.GetComponent<Image>();
                _img.sprite = img;
            }

            public void ChangeImage(Image obj, Sprite img) => obj.sprite = img;
        }

        [Serializable]
        public class AnimationButton
        {
            [Header("Position")]
            public Vector2 newVector2;
            public Vector3 newVector3;
            public float newPos;

            [Header("Timer")]
            public float duration;

            [Header("Anmimation")]
            public LeanTweenType style;
            public AnimationType type;
            public bool isAnimated;
        }

        [SerializeField]
        private string _id;
        public string ID
        {
            get => _id;
            set => _id = value;
        }


        [SerializeField]
        private bool _haveText = true;

        [SerializeField] 
        private bool _canChangeSprite = false;

        [Space(5)]
        [SerializeField]
        private List<ImageButton> _templateImageButton = new List<ImageButton>();

        [Space(5)]
        public AnimationButton _anim;
        public UnityEvent OnClicked;

        
        private Button _thisButton;
        private TextMeshProUGUI _text;

        private void Awake()
        {
            if (_thisButton == null)
                _thisButton = this.transform.GetChild(0).GetComponent<Button>();
            if (_text == null && _thisButton.transform.childCount != 0)
                _text = _thisButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            if (!_canChangeSprite)
                _templateImageButton = null;
        }

        private void Start()
        {
            SetGameObjectName();
            SetAnimation(_anim.type);
            SetTMPText(_id);
        }

        private void SetGameObjectName()
        {
            GameObject _button = _thisButton.gameObject;
            GameObject _parentButton = this.gameObject;

            string _thisGameObjectName = _button.name;
            string _prefix = "Button ";
            string _sufix = " Viewport";

            _thisGameObjectName =
                _thisGameObjectName == _id ? _prefix + _thisGameObjectName : _prefix + _id;
            string _parentGameObject = _prefix + _id + _sufix;

            _button.name = _thisGameObjectName;
            _parentButton.name = _parentGameObject;
        }

        private void SetAnimation(AnimationType type)
        {
            if (!_anim.isAnimated || _thisButton == null)
                return;

            switch (type)
            {
                case AnimationType.MoveX:
                    _thisButton.transform
                        .LeanMoveX(_anim.newPos,_anim.duration)
                        .setEase(_anim.style)
                        .setLoopPingPong();
                    break;

                case AnimationType.MoveY:
                    _thisButton.transform
                        .LeanMoveY(_anim.newPos, _anim.duration)
                        .setEase(_anim.style)
                        .setLoopPingPong();
                    break;

                case AnimationType.MoveLocalX:
                    _thisButton.transform
                        .LeanMoveLocalX(_anim.newPos, _anim.duration)
                        .setEase(_anim.style)
                        .setLoopPingPong();
                    break;

                case AnimationType.MoveLocalY:
                    _thisButton.transform
                        .LeanMoveLocalY(_anim.newPos, _anim.duration)
                        .setEase(_anim.style)
                        .setLoopPingPong();
                    break;

                case AnimationType.Scale:
                    _thisButton.transform
                        .LeanScale(_anim.newVector3,_anim.duration)
                        .setEase(_anim.style)
                        .setLoopPingPong();
                    break;

                default:
                    _thisButton.transform
                        .LeanMove(_anim.newVector3, _anim.duration)
                        .setEase(_anim.style)
                        .setLoopPingPong();
                    break;
            }
        }

        private void SetTMPText(string name)
        {
            _text.gameObject.SetActive(_haveText);
            _text.text = name;
        }
        public void ButtonHelperInvoke() => OnClicked.Invoke();
    }
}
