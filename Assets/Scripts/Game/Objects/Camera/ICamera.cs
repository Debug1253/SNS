using UnityEngine;

namespace sns.ActionCamera
{
    public interface ICamera
    {
        float ScreenSize { get; }

        void UpdatePosition(Transform cameraTransform, Vector3 targetPos);
    }
}