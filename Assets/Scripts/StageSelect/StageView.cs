using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

public class StageView : MonoBehaviour
{
    [SerializeField] private List<Button> levelButtons;

    private Subject<int> onLevelButton = new Subject<int>();

    public IObservable<int> OnLevelButton { get { return onLevelButton; } }

    private void Start()
    {
        InitEvent();
    }

    private void InitEvent()
    {
        levelButtons.Select((button, index) => new { button, index })
            .ToList()
            .ForEach(vo =>
            {
                vo.button.OnClickAsObservable()
                    .Subscribe(_ => onLevelButton.OnNext(vo.index))
                    .AddTo(this);
            });
    }
}
