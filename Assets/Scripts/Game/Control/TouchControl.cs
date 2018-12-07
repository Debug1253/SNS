using System;

namespace sns.Control
{
    public class TouchControl : IControl
    {
        public IObservable<float> OnHorizontal() { return null; }
        public IObservable<float> OnVertical() { return null; }
        public IObservable<bool> OnJump() { return null; }
    }
}