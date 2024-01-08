using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : CustomSingleTon<UIController>
{
    private UIModel _model;
    private UIView _view;

    private void Awake()
    {
        _model = new UIModel();
        _view = GetComponent<UIView>();
    }
}
