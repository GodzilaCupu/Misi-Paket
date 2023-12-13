using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GodzillaCupu.Player;
using TMPro;
using UnityEngine;

namespace GodzillaCupu.Manager
{
    public class DropdownConfiguration : MonoBehaviour
    {
        [SerializeField] private InputHandler input;
        [SerializeField] private PlatformManager platform;
        [SerializeField] private GameObject dropdownObj;
        [SerializeField] private TMP_Dropdown dropdownTMP;

        [SerializeField] List<TMP_Dropdown.OptionData> data;

        public TMP_Dropdown.OptionData currentValueData
        {
            get => data[dropdownTMP.value];
        }

        public string currentStringValue
        {
            get => data[dropdownTMP.value].text;
        }

        public int currentIntValue
        {
            get => dropdownTMP.value;
        }


        void Start()
        {
            if (input == null) input = InputHandler.instance;
            if (platform == null) platform = PlatformManager.instance;

            FillData(dropdownTMP);
            ChangeJoystickType(input.JoystickType);
        }

        void Update()
        {
            
        }

        private void FillData(TMP_Dropdown dropdown) => data = dropdown.options;


        public void ChangeJoystickType(JoystickType type)
        {
            string _stringType = type.ToString();

            //Change Value In Dropdown
            TMP_Dropdown.OptionData tempTargetValue = data.Find(x => x.text == _stringType);
            int targetValue = data.IndexOf(tempTargetValue);

            dropdownTMP.value = targetValue;
            dropdownTMP.RefreshShownValue();

            //Change Input Joystick
            input.JoystickType = type;
            input._joystick.SetMode(input.JoystickType);
        }

        public void ChangeJoystickType(TMP_Dropdown dropdown)
        {
            string _stringValue = data[dropdown.value].text;

            //Get Type
            JoystickType tempType;
            int _intValue = dropdown.value;
            tempType = (JoystickType)_intValue;

            //Change Input Joystick
            input.JoystickType = tempType;
            input._joystick.SetMode(input.JoystickType);

        }
    }
}