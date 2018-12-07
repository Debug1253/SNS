using System;
using UnityEngine;
using sns.InputEvent;

namespace sns.Title
{
    public class TitleSceneView : MonoBehaviour
    {
        public IObservable<bool> OnTap { get { return InputEventService.Instance.OnTap(); } }
    }
}