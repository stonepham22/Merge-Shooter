using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class MyAddressables : MonoBehaviour
{
    public static async Task<GameObject> LoadAssetAsync(string name)
    {
        AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(name);

        try
        {
            await handle.Task;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                return Instantiate(handle.Result);
            }
            else
            {
                Debug.LogError("Failed to load prefab. Status: " + handle.Status);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Exception occurred while loading prefab: " + ex.Message);
        }
        return null;
    }
}
