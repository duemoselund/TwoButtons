using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    //add proper dispatcher pattern due to calling things from other thread https://www.what-could-possibly-go-wrong.com/the-dispatcher-pattern/
    readonly List<Action> dispatched = new List<Action>();
    ClickHandler clickHandler;
    Image buttonImage;
    Button thisButton;

    // Start is called before the first frame update
    void Start()
    {
        buttonImage = GetComponent<Image>();
        clickHandler = new ClickHandler(new DefaultSystemTimer());

        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(() => clickHandler.ButtonClicked());

        SetConditions();
    }

    void SetConditions()
    {
        //why 2000  and not 2?
        //prob save as variables..?
        clickHandler.AddColorCondition(2000, 1, () =>
        {
            dispatched.Add(() => buttonImage.color = Color.blue);
        });
        clickHandler.AddColorCondition(2000, 2, () =>
        {
            dispatched.Add(() => buttonImage.color = Color.red);
        });
        clickHandler.AddColorCondition(2000, 5, () =>
        {
            dispatched.Add(() => buttonImage.color = new Color(0.5f, 0, 0.5f));
        });
        clickHandler.AddColorCondition(5000, 0, () =>
        {
            dispatched.Add(() => buttonImage.color = Color.green);
        }); // aka default color;
    }

    void Update()
    {
        dispatched.ForEach(x => { x?.Invoke(); });
        dispatched.Clear();
    }
}