using System.Collections.Generic;

namespace sns.Character
{
    public enum CharaType
    {
        Hanzo = 0,
        Ninza,
        Robot,
    }

    public class CharactersModel
    {
        public Dictionary<CharaType, CharacterModel> Characters { get; private set; }

        public CharactersModel()
        {
            Characters = new Dictionary<CharaType, CharacterModel>();

            Characters.Add(CharaType.Hanzo, new CharacterModel(CharaType.Hanzo));
            Characters.Add(CharaType.Ninza, new CharacterModel(CharaType.Ninza));
            Characters.Add(CharaType.Robot, new CharacterModel(CharaType.Robot));
        }
    }
}