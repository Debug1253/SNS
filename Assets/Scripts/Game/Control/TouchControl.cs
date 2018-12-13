using System;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using sns.Path;

using UniRx;

namespace sns.Control
{
    public class TouchControl : MonoBehaviour, IControl, IDragHandler, IEndDragHandler
    {
        [SerializeField] private Button jumpButton;
        [SerializeField] private RectTransform bg;
        [SerializeField] private Transform stick;

        public IObservable<float> OnHorizontal() { return onHorizontal; }
        public IObservable<float> OnVertical() { return onVertical; }
        public IObservable<bool> OnJump() { return jumpButton.OnClickAsObservable().Select(_ => true); }

        private Subject<float> onHorizontal = new Subject<float>();
        private Subject<float> onVertical = new Subject<float>();

        private Vector2 stickDefaultPos;
        private Vector2 stickDir;
        private float radius;

		private void Start()
		{
            Initialize();
		}

        private void Initialize()
        {
            radius = bg.sizeDelta.y * 0.5f;
            stickDefaultPos = stick.localPosition;
        }

        public virtual void OnDrag(PointerEventData data)
        {
            stickDir = (data.position - stickDefaultPos).normalized;

            var distance = Vector3.Distance(data.position, stickDefaultPos);
            var pos = stickDir * Mathf.Min(distance, radius);
            stick.localPosition = stickDefaultPos + pos;

            onHorizontal.OnNext(pos.x / radius);
            onVertical.OnNext(pos.y / radius);
        }

        public virtual void OnEndDrag(PointerEventData data)
        {
            stick.localPosition = stickDefaultPos;
            stickDir = Vector2.zero;

            onHorizontal.OnNext(0f);
            onVertical.OnNext(0f);
        }
	}
}