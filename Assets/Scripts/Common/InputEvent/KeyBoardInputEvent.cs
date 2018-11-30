using System;
using UnityEngine;

using UniRx;

namespace sns.InputEvent
{
    public class KeyBoardInputEvent : IInputEvent
    {
        public IObservable<float> OnHorizontal() { return Observable.EveryUpdate().Select(_ => Input.GetAxis("Horizontal")).Where(h => h != 0); }
        public IObservable<float> OnVertical() { return Observable.EveryUpdate().Select(_ => Input.GetAxis("Vertical")).Where(v => v != 0); }
        public IObservable<bool> OnJump() { return Observable.EveryUpdate().Select(_ => Input.GetKey(KeyCode.Z)).DistinctUntilChanged(); }
        public IObservable<bool> OnTap() { return Observable.EveryUpdate().Select(_ => Input.GetMouseButtonUp(0)).DistinctUntilChanged(); }
    }
}