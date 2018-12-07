using System;

namespace sns.Control
{
    public interface IControl
    {
        IObservable<float> OnHorizontal();
        IObservable<float> OnVertical();
        IObservable<bool> OnJump();
    }
}