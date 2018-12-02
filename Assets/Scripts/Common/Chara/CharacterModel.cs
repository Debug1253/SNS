using UnityEngine;
using sns.Path;

namespace sns.Character
{
    public class CharacterModel
    {
        public CharaType Type { get; private set; }

        public CharacterModel(CharaType type)
        {
            Type = type;
        }
    }
}