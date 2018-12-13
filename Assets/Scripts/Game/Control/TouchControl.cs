using System;

using UnityEngine;
using UnityEngine.UI;

using sns.Path;

using UniRx;

namespace sns.Control
{
    public class TouchControl : MonoBehaviour, IControl
    {
        [SerializeField] private Button jumpButton;
        //[SerializeField] private Button moveStick;

        public IObservable<float> OnHorizontal() { return Observable.Return(0f); }
        public IObservable<float> OnVertical() { return Observable.Return(0f); }
        public IObservable<bool> OnJump() { return jumpButton.OnClickAsObservable().Select(_ => true); }
    }
}