using UnityEditor.U2D.Animation;
using UnityEngine;

public static class UIToWorldPosition 
{
    // public RectTransform uiObject;  // Object trong Canvas (UI)
    // public Transform worldObject;   // Object ngoài Canvas (non-UI)
    // public Camera uiCamera;         // Camera gắn với UI, thường là Camera chính nếu Canvas sử dụng Screen Space - Camera hoặc World Space

    // void FixedUpdate()
    // {
    //     // Chuyển đổi tọa độ từ Screen Space hoặc RectTransform sang World Space
    //     Vector3 worldPosition = ConvertUIToWorldPosition(uiObject);

    //     // Gán vị trí mới cho object ngoài Canvas
    //     // worldObject.position = worldPosition;
    //     Debug.Log("World Position: " + worldPosition);
    // }

    public static Vector3 ConvertUIToWorldPosition(RectTransform rectTransform)
    {
        // Lấy vị trí của UI object (RectTransform) trong không gian màn hình (Screen Space)
        Vector3 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, rectTransform.position);

        // Chuyển đổi Screen Space thành World Space
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPoint);

        // Đảm bảo Z-value phù hợp với đối tượng ngoài Canvas
        worldPosition.z = 0;  // Có thể điều chỉnh Z theo ý muốn, hoặc dựa trên Camera chính

        return worldPosition;
    }
}
