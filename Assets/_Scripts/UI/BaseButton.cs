using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : LoboBehaviour
{
    
    [SerializeField] protected Button button;

    protected override void LoadComponents()
    {
        LoadButton();
    }

    void LoadButton()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    protected abstract void OnClick();
}
