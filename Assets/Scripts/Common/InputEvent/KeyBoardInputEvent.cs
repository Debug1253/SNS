using System;
using UnityEngine;

using UniRx;

namespace sns.InputEvent
{
    public class KeyBoardInputEvent : IInputEvent
    {
        public IObservable<float> OnHorizontal() { return Observable.EveryUpdate().Select(_ => Input.GetAxis("Horizontal")).DistinctUntilChanged(); }
        public IObservable<float> OnVertical() { return Observable.EveryUpdate().Select(_ => Input.GetAxis("Vertical")).DistinctUntilChanged(); }
        public IObservable<bool> OnJump() { return Observable.EveryUpdate().Select(_ => Input.GetKey(KeyCode.Z)).DistinctUntilChanged(); }
        public IObservable<bool> OnTap() { return Observable.EveryUpdate().Select(_ => Input.GetMouseButtonUp(0)).DistinctUntilChanged(); }
    }
}