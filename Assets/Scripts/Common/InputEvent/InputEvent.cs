namespace sns.InputEvent
{
    public class InputEventService
    {
        // NOTE: 싱글톤
        private static InputEventService instance;
        public static InputEventService Instance
        {
            get
            {
                if (instance == null)
                    instance = new InputEventService();

                return instance;
            }
        }

        private IInputEvent inputEvent;

        private InputEventService()
        {
            Initialize();
        }

        private void Initialize()
        {
#if UNITY_ANDROID || UNITY_IOS
            inputEvent = new TouchInputEvent();
#elif UNITY_STANDALONE || UNITY_EDITOR
            inputEvent = new KeyBoardInputEvent();
#endif
        }

        public IInputEvent GetInputEvent()
        {
            return inputEvent;
        }
    }
}
