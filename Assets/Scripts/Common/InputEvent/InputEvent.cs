using System;
using UnityEngine;

using UniRx;

namespace sns.InputEvent
{
    public class InputEventService
    {
        // NOTE: 싱글톤
        private static InputEventService instance;
        public static InputEventService Instance
        {
            get
            {
                if (instance == null)
                    instance = new InputEventService();

                return instance;
            }
        }

        public IObservable<bool> OnTap()
        {
            return Observable.EveryUpdate().Select(_ => Input.GetMouseButtonUp(0)).DistinctUntilChanged();
        }
    }
}
