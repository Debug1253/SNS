using System;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

public class GameView : MonoBehaviour
{
    [SerializeField] private Button goToTitleButton; // NOTE: 더미

    public IObservable<Unit> OnGoToTitle { get { return goToTitleButton.OnClickAsObservable(); } }
}
