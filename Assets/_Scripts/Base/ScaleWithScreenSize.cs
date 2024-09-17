using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWithScreenSize : MonoBehaviour
{
    [SerializeField] private float _screenWidth;
    [SerializeField] private float _screenHeight;
    [SerializeField] private float _offset = 0.075f;// gun = 0.075, monster = 0.2

    void Reset()
    {
        _screenHeight = Screen.height;
        _screenWidth = Screen.width;
    }

    void Start()
    {
        float scaleWith = _screenWidth / Screen.width;
        float scaleHeight = _screenHeight / Screen.height;

        transform.localScale = new Vector3(transform.localScale.x * (scaleWith + _offset),
                        transform.localScale.y * (scaleHeight + _offset), transform.localScale.z);
    }

}
