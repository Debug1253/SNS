using System;
using UnityEngine;

using UniRx;

public class TitleSceneView : MonoBehaviour
{
    public IObservable<bool> OnTap { get { return Observable.EveryUpdate().Select(_ => Input.GetMouseButtonUp(0)).DistinctUntilChanged(); } }
}
