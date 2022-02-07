namespace JavaPattern
{
    public class StateColorButton : ColorButton
    {
        void Awake()
        {
            ColorButtonBehaviour = new StateSpecificColor();
        }
    }
}