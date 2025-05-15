using UnityEngine;
namespace Mangkus.Input
{
    public class KeyboardInput : MonoBehaviour, IMovementInput
    {
        public Vector3 GetMoveDirection()
        {
            float h = UnityEngine.Input.GetAxisRaw("Horizontal");
            float v = UnityEngine.Input.GetAxisRaw("Vertical");
            return new Vector3(h, 0f, v).normalized;
        }
    }
}