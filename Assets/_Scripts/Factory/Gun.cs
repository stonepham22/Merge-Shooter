using UnityEngine;

public class Gun : Product
{
    protected override void OnDisable()
    {
        base.OnDisable();
        // Remove to lobby
        LobbyCtrl.SetEmpty(transform.position);
        
        // Notify event to observer
        Observer.Notify(EventType.NotFullLobby, null);
    }
}
