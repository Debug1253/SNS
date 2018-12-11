using sns.Character;

namespace sns.Path
{
    public class PathModel
    {
        // 메인메뉴 관련
        public const string CharaSelectPrefabPath = "MainMenu/CharaSelectDialog";

        // FIXME: AssetBundle로 관리하자
        // 캐릭 아이콘 이미지
        static public string GetCharaPath(CharaType type)
        {
            switch (type)
            {
                case CharaType.Hanzo: return "Characters/Chara_1";
                case CharaType.Ninza: return "Characters/Chara_2";
                case CharaType.Robot: return "Characters/Chara_3";
                default: throw new System.Exception("유효한 CharaType이 아닙니다.");
            }
        }
    }
}