using UnityEngine;

namespace Mangkus.Player.Input
{
    public class InputJoystickView : MonoBehaviour
    {
        [Header("Joystick View")]
        private GameObject joystickObject;
        private Joystick joystickProvider;
        public Joystick GetJoystickProvider => joystickProvider;

        public void InitilizedJoystick(GameObject joystickPrefab, Transform transformParent)
        {
            if (joystickPrefab != null)
            {
                joystickObject = Instantiate(joystickPrefab, transformParent);

                joystickProvider = joystickObject.GetComponent<Joystick>();
            }
            else
            {
                Debug.LogError("Joystick prefab is not assigned.");
            }
        }
    }
}
