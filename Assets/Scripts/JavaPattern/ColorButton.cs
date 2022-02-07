using UnityEngine;
using UnityEngine.UI;

namespace JavaPattern
{
    public abstract class ColorButton : MonoBehaviour
    {
        Image buttonImage;

        protected IColorButtonBehaviour ColorButtonBehaviour;
        Button thisButton;

        void Start()
        {
            thisButton = GetComponent<Button>();
            thisButton.onClick.AddListener(ColorButtonBehaviour.OnButtonClicked);
            buttonImage = GetComponent<Image>();
        }
    }
}