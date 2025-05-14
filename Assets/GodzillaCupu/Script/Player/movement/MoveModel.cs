using UnityEngine;

public class MoveModel
{
    public float moveSpeed{get ; private set;} = 5f;
    public float rotationSpeed {get ; private set;} = 720f;

    public void SetMoveSpeed(float _moveSpeed) => moveSpeed = moveSpeed;
    public void SetRotationSpeed(float _rotationSpeed) => rotationSpeed = _rotationSpeed;
}
