using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
/// <summary>
/// This script is used to move the object to the target position using DOTween.
/// </summary>
public class MoveObjectWithDOTween : MonoBehaviour
{
    [SerializeField] private float _targetPositionY;
    [SerializeField] private float _duration;
    private Tween _moveTween;
    
    /// <summary>
    /// Move the object to targetPosition over the duration.
    /// </summary>
    /// <param name="targetPosition"></param>
    /// <param name="duration"></param>
    public void Move(Vector3 targetPosition, float duration)
    {
        // Apply easing InOutQuad to make the movement smoother.
        _moveTween = transform.DOMove(targetPosition, duration)
                              .SetEase(Ease.InOutQuad)
                              .OnComplete (() => gameObject.SetActive(false));
    }

    void OnEnable()
    {
        Move(new Vector3(transform.position.x, _targetPositionY, 0), _duration);
    }

    void OnDisable()
    {
        // Kill the tween if it is still active when the object is disabled.
        if (_moveTween != null && _moveTween.IsActive())
        {
            _moveTween.Kill();
        }
    }

}
