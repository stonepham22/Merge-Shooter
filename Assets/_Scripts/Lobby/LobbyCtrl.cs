using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LobbyCtrl 
{
    private static Dictionary<Vector3, bool> _spawnPositions = new Dictionary<Vector3, bool>();

    public static void Add(Transform rectTransform)
    {
        Vector3 worldPosition = MyCalculator.ConvertUIToWorldPosition((RectTransform)rectTransform);
        _spawnPositions.Add(worldPosition, false);
    }
    public static Vector3 GetEmptyPosition()
    {
        // Iterate through all positions in the _spawnPositions
        foreach(var position in _spawnPositions)
        {
            // If the position is empty, set it to true and return the position
            if (!position.Value)
            {
                // Set the position to true to indicate that it is no longer empty
                _spawnPositions[position.Key] = true;
                return position.Key;
            }
        }

        Observer.Notify(Type.FullLobby, null);

        return Vector3.zero;
    }
}
