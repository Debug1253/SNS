using System;

namespace sns.InputEvent
{
    public class TouchInputEvent : IInputEvent
    {
        // FIXME: 나중에 터치입력추가 예정
        public IObservable<float> OnHorizontal() { return null; }
        public IObservable<float> OnVertical() { return null; }
        public IObservable<bool> OnJump() { return null; }
        public IObservable<bool> OnTap() { return null; }
    }
}