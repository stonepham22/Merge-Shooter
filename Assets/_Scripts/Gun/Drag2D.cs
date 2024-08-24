using UnityEngine;

public class Drag2D : MonoBehaviour
{
    private Vector3 _offset;
    public Transform SnapPoint;

    void OnMouseDown()
    {
        // Get the offset between the object's position and the mouse's position
        _offset = transform.position - GetMouseWorldPos();
    }

    void OnMouseDrag()
    {
        // Set the object's position to the mouse's position + the offset
        transform.position = GetMouseWorldPos() + _offset;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 10f; // Distance from the camera
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseUp()
    {
        float minDistance = float.MaxValue;
        Vector3 closestSnapPoint = Vector3.zero;
        foreach (Transform snapPoint in SnapPoint)
        {
            float distance = Vector3.Distance(transform.position, snapPoint.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestSnapPoint = snapPoint.position;
            }
        }
        transform.position = closestSnapPoint;
    }

}
