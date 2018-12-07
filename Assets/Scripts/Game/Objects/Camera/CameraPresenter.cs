using System;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

namespace sns.ActionCamera
{
    public enum CameraType
    {
        FocusTarget,
        FixedVertical,
    }

    [RequireComponent(typeof(Camera))]
    public class CameraPresenter : MonoBehaviour
    {
        [SerializeField] private GameObject target;
        [SerializeField] private CameraType type;
        [SerializeField] private Vector3 positionAdjustment;

        private Camera CameraComponent { get { return GetComponent<Camera>(); } }

        private Dictionary<CameraType, ICamera> cameras = new Dictionary<CameraType, ICamera>();

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            cameras.Add(CameraType.FocusTarget, new FocusTargetCamera());
            cameras.Add(CameraType.FixedVertical, new FixedVerticalCamera());

            CameraComponent.orthographicSize = cameras[type].ScreenSize;

            InitEventHandler();
        }

        private void InitEventHandler()
        {
            target.transform.ObserveEveryValueChanged(t => t.position)
                .Subscribe(pos => cameras[type].UpdatePosition(transform, pos + positionAdjustment))
                .AddTo(this);
        }
    }
}