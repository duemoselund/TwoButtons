using UnityEngine;

namespace StrategyPattern
{
    public class RandomColorButton : MonoBehaviour, IColorBehaviour
    {
        public void Behaviour(ColorButton colorButton)
        {
        }

        public Color GetNewColor()
        {
            Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            return color;
        }
    }
}