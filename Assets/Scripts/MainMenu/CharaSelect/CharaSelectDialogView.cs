using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using sns.Character;

using UniRx;

namespace sns.MainMenu
{
    public class CharaSelectDialogView : MonoBehaviour
    {
        [SerializeField] private List<CharaSelectDialogCharaView> chara;

        private Subject<CharaType> onCharaSelect = new Subject<CharaType>();

        public IObservable<CharaType> OnCharaSelect { get { return onCharaSelect; } }

        private void Start()
        {
            InitEvent();
        }

        private void InitEvent()
        {
            chara.Select((view, index) => new { view, index })
                .ToList()
                .ForEach(vo => vo.view.OnCharaSelect.Subscribe(_ => onCharaSelect.OnNext((CharaType)vo.index)).AddTo(this));
        }
        
        public void Draw()
        {
            // NOTE: 나중에 아이콘, 내용을 데이터로 관리하면 사용
        }
    }
}