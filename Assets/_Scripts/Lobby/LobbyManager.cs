using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script manages the lobbies where guns are spawned
/// </summary>
public class LobbyManager : MonoBehaviour
{
    private Dictionary<Vector3, bool> _spawnPositions = new Dictionary<Vector3, bool>();

    private void Start()
    {
        LoadSpawnPositions();
    }

    /// <summary>
    /// Retrieves all the positions of the 12 lobbies in the game 
    /// Converts them to vectors to store in the array
    /// </summary>
    private void LoadSpawnPositions()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Vector3 worldPosition = MyCalculator.ConvertUIToWorldPosition(transform.GetChild(i) as RectTransform);
            _spawnPositions.Add(worldPosition, false);
        }
    }
    /// <summary>
    /// Returns a Vector3 which is the position of an empty lobby where a gun can be spawned
    /// </summary>
    public Vector3 GetEmptyPosition()
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
