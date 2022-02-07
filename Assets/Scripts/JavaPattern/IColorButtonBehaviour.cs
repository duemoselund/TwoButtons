using UnityEngine;

namespace JavaPattern
{
    public interface IColorButtonBehaviour
    {
        public Color GetNewColor();

        public void OnButtonClicked();
    }
}