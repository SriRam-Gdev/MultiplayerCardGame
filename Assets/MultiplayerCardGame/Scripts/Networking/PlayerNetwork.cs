using Mirror;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    public static PlayerNetwork LocalPlayer;

    public override void OnStartLocalPlayer()
    {
        LocalPlayer = this;
        Debug.Log("Local player ready");
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
    }
}
