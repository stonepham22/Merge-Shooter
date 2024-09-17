using UnityEngine;

/// <summary>
/// Converts the position of a UI GameObject (RectTransform) within a Canvas to a position in the game world.
/// /// This class provides methods for performing various calculations in Unity
/// </summary>
public static class MyCalculator
{
    /// <summary>
    /// Converts the position of a GameObject within a Canvas to a position in the game world
    /// </summary>
    /// <param name="rectTransform">The RectTransform of the UI element to be converted</param>
    /// <returns>The position of the UI element in the game world</returns>
    public static Vector3 ConvertUIToWorldPosition(RectTransform rectTransform)
    {
        // Get the position of the UI object (RectTransform) in screen space
        Vector3 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, rectTransform.position);

        // Convert screen space to world space
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPoint);

        // Ensure the Z-value is appropriate for objects outside the Canvas
        worldPosition.z = 0;  // Adjust Z as needed, or based on the main Camera

        return worldPosition;
    }

    /// <summary>
    /// Aligns the position of a GameObject outside the game view along the positive y-axis
    /// </summary>
    /// <param name="position">The position of the game object in the game view</param>
    /// <param name="offset">The offset distance from the top edge of the screen</param>
    /// <returns></returns>
    public static Vector3 GetPositionOverScreen(Vector3 position, float offset)
    {
        // Get the position of the top of the camera
        Camera mainCamera = Camera.main;
        Vector3 topOfCamera = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 1.0f, position.z - mainCamera.transform.position.z));

        // Calculate the distance along the y-axis
        float verticalDistance = Mathf.Abs(position.y - topOfCamera.y);
        return new Vector3(position.x, position.y + verticalDistance + offset, position.z);
    }
}