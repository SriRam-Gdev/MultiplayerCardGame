using Mirror;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    public static PlayerNetwork LocalPlayer;

    void Start()
    {
        if (isLocalPlayer)
            LocalPlayer = this;
    }

    [Command]
    public void CmdSendJson(string json)
    {
        RpcReceiveJson(json);
    }

    [ClientRpc]
    void RpcReceiveJson(string json)
    {
        if (GameMessageRouter.Instance != null)
            GameMessageRouter.Instance.Handle(json);
        else
            Debug.LogError("GameMessageRouter not found in scene!");
    }
}
