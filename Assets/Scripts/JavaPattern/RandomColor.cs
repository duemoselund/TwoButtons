using UnityEngine;

namespace JavaPattern
{
    public class RandomColor : IColorButtonBehaviour
    {
        public Color GetNewColor()
        {
            Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            Debug.Log("Random Color " + color);
            return color;
        }

        public void OnButtonClicked()
        {
            GetNewColor();
        }
    }
}