using System;
using System.Collections.Generic;
using UnityEngine;

using sns.Control;
using sns.Path;

using UniRx;

namespace sns.Player
{
    public class PlayerView : MonoBehaviour
    {
        public IObservable<float> OnHorizontal { get { return control.OnHorizontal(); } }
        public IObservable<float> OnVertical { get { return control.OnVertical(); } }
        public IObservable<bool> OnJump { get { return control.OnJump(); } }

        private IControl control;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
#if UNITY_ANDROID || UNITY_IOS
			control = new KeyBoardControl();
#elif UNITY_STANDALONE || UNITY_EDITOR
            var prefab = Resources.Load(PathModel.TouchControlUIPrefabPath);
            var go = Instantiate(prefab) as GameObject;
            control = go.GetComponent<TouchControl>();
#endif
        }
    }
}