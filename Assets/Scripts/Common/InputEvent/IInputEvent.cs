using System;

namespace sns.InputEvent
{
    public interface IInputEvent
    {
        IObservable<float> OnHorizontal();
        IObservable<float> OnVertical();
        IObservable<bool> OnJump();
        IObservable<bool> OnTap();
    }
}