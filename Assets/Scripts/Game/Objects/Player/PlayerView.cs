using System;
using System.Collections.Generic;
using UnityEngine;

using sns.InputEvent;

using UniRx;

namespace sns.Player
{
    public class PlayerView : MonoBehaviour
    {
        public IObservable<float> OnHorizontal { get { return InputEventService.Instance.GetInputEvent().OnHorizontal(); } }
        public IObservable<float> OnVertical { get { return InputEventService.Instance.GetInputEvent().OnVertical(); } }
        public IObservable<bool> OnJump { get { return InputEventService.Instance.GetInputEvent().OnJump(); } }
    }
}