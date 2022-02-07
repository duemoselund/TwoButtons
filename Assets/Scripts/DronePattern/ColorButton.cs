using UnityEngine;
using UnityEngine.UI;

namespace StrategyPattern
{
    public class ColorButton : MonoBehaviour
    {
        Button thisButton;

        public void ApplyColorBehavior(IColorBehaviour colorBehaviour)
        {
            colorBehaviour.Behaviour(this);
        }
    }
}