using UnityEngine;
using sns.Character;

namespace sns.Data
{
    public class DataService
    {
        private static DataService instance;
        public static DataService Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataService();

                return instance;
            }
        }

        public void SaveCurrentChara(CharaType type)
        {
            PlayerPrefs.SetInt(DataModel.CharaDataName, (int)type);
        }

        public CharaType LoadCurrentChara()
        {
            return (CharaType)PlayerPrefs.GetInt(DataModel.CharaDataName);
        }
    }
}