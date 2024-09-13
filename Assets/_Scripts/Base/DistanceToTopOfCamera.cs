using UnityEngine;

public static class DistanceToTopOfCamera
{
    public static Vector3 GetPositionOverScreen(Vector3 position, float offset)
    {
        // Lấy vị trí của phía trên cùng của camera
        Camera mainCamera = Camera.main;
        Vector3 topOfCamera = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 1.0f, position.z - mainCamera.transform.position.z));

        // Tính khoảng cách theo trục y
        float verticalDistance = Mathf.Abs(position.y - topOfCamera.y);
        return new Vector3(position.x, position.y + verticalDistance + offset, position.z);
    }
}