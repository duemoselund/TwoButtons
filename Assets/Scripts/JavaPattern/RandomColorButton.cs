namespace JavaPattern
{
    public class RandomColorButton : ColorButton
    {
        void Awake()
        {
            ColorButtonBehaviour = new RandomColor();
        }
    }
}