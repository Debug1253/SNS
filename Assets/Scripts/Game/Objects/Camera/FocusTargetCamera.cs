using UnityEngine;

namespace sns.ActionCamera
{
    public class FocusTargetCamera : ICamera
    {
        private const float FOCUS_TARGET_SCREEN_SIZE = 500;

        public float ScreenSize { get; private set; }

        public FocusTargetCamera()
        {
            ScreenSize = FOCUS_TARGET_SCREEN_SIZE;
        }

        public void UpdatePosition(Transform cameraTransform, Vector3 targetPos)
        {
            cameraTransform.position = targetPos + Vector3.back;
        }
    }
}