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
        var mousePoint = Input.mousePosition;
        mousePoint.z = 10f; // Distance from the camera
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseUp()
    {
        float minDistance = float.MaxValue;
        Transform closestSnapPoint = null;

        // Find the closest snap point and closest transform
        foreach (Transform snapPoint in SnapPoint)
        {
            // Calculate the distance between the object and the snap point
            float distance = Vector3.Distance(transform.position, snapPoint.position);

            // If the distance is less than the minimum distance, set the minimum distance to the distance
            if (distance < minDistance)
            {
                minDistance = distance;
                closestSnapPoint = snapPoint;
            }
        }

        // If the closest snap point has no children, snap the object to the snap point
        if (closestSnapPoint.childCount == 0)
        {
            // Set the object's position to the closest snap point
            transform.position = closestSnapPoint.position;

            // Set the object's parent to the snap point
            transform.SetParent(closestSnapPoint);
        }

        // If the closest snap point has children, swap the object with the gun in the snap point
        else
        {
            var gunInClosest = closestSnapPoint.GetChild(0);
            gunInClosest.SetParent(transform.parent);
            gunInClosest.localPosition = Vector3.zero;
            transform.SetParent(closestSnapPoint);
            transform.localPosition = Vector3.zero;
        }
    }

}
