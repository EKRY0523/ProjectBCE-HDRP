using UnityEngine;

public class ReinvokeParty : MonoBehaviour
{
    public PartyHandler handler;

    private void OnDisable()
    {
        handler.MBEvent?.Invoke(null,handler.party);
        handler.MBEvent?.Invoke(null, handler.activeCharacter);
    }
}
