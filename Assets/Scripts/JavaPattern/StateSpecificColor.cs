using TMPro;
using UnityEngine;

namespace JavaPattern
{
    public class StateSpecificColor : IColorButtonBehaviour
    {
        public TextMeshProUGUI buttonText;
        bool isTimeRunning;
        float resetTimer;
        float timer;


        public int ClickCount { get; private set; }

        public Color GetNewColor()
        {
            Color color = Color.gray;

            switch (ClickCount)
            {
                case 0:
                    color = Color.green;
                    break;
                case 1:
                    color = Color.blue;
                    break;
                case 2:
                    color = Color.red;
                    break;
                case 5:
                    color = new Color(0.5f, 0, 0.5f);
                    break;
            }

            Debug.Log("State Color " + color);
            return color;
            // Here the the timer should be called first
        }

        public void OnButtonClicked()
        {
            isTimeRunning = true;
            resetTimer = 0;
            Count();
            Debug.Log("ClickCount " + ClickCount);
        }

        void Update()
        {
            resetTimer += Time.deltaTime;
            if (resetTimer > 5)
            {
                ResetState();
            }

            if (isTimeRunning)
            {
                RunTime();
            }
        }

        void Count()
        {
            if (timer < 2)
            {
                ClickCount++;
            }
        }

        void RunTime()
        {
            timer += Time.deltaTime;
            Debug.Log("Timer " + timer);
            if (timer > 2)
            {
                GetNewColor();
                timer = 0;
                isTimeRunning = false;
            }
        }

        void ResetState()
        {
            timer = 0;
            ClickCount = 0;
            GetNewColor();
        }
    }
}