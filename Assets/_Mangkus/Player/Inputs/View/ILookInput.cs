using UnityEngine;

namespace Mangkus.Player.Input
{
    public interface ILookInput
    {
        Vector3 GetLookDirection();
        Vector3 GetLookRotation();
    }
}
