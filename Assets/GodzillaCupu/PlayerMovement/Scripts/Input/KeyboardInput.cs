using UnityEngine;

public class KeyboardInput : MonoBehaviour, IMovementInput
{
    public Vector3 GetMoveDirection()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        return new Vector3(h, 0f, v).normalized;
    }
}