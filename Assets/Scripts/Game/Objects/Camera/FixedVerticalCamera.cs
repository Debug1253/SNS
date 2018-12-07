using UnityEngine;

namespace sns.ActionCamera
{
    public class FixedVerticalCamera : ICamera
    {
        private const float FIXED_VERTICAL_SCREEN_SIZE = 750;
        
        public float ScreenSize { get; private set; }

        public FixedVerticalCamera()
        {
            ScreenSize = FIXED_VERTICAL_SCREEN_SIZE;
        }

        public void UpdatePosition(Transform cameraTransform, Vector3 targetPos)
        {
            var temp = cameraTransform.position;
            temp.x = targetPos.x;
            cameraTransform.position = temp;
        }
    }
}