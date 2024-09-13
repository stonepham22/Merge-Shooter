using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : LoboBehaviour
{
    [SerializeField] private Button _button;

    protected override void LoadComponents()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }
    
    protected abstract void OnClick();
}
