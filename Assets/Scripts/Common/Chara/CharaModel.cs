namespace sns.Character
{
    public enum CharaType
    {
        Hanzo = 0,
        Ninza,
        Robot,
    }

    public class CharaModel
    {
        public CharaType Type { get; private set; }

        public CharaModel(CharaType type)
        {
            Type = type;
        }
    }
}