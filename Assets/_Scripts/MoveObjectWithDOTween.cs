using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
/// <summary>
/// This script is used to move the object to the target position using DOTween.
/// </summary>
public class MoveObjectWithDOTween : MonoBehaviour
{
    /// <summary>
    /// Move the object to targetPosition over the duration.
    /// </summary>
    /// <param name="targetPosition"></param>
    /// <param name="duration"></param>
    public void Move(Vector3 targetPosition, float duration)
    {
        // Apply easing InOutQuad to make the movement smoother.
        transform.DOMove(targetPosition, duration)
                 .SetEase(Ease.InOutQuad)
                 .OnComplete(OnMoveComplete);
    }

    void OnMoveComplete()
    {
        // Deactivate the object when the movement is complete.
        gameObject.SetActive(false);        
    }

    void OnEnable()
    {
        Move(new Vector3(transform.position.x, 6, 0), 2);
    }

}
