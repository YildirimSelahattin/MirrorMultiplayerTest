using Mirror;
using PaintIn3D;
using UnityEngine;

public class PlayerManager : NetworkBehaviour
{
    GameObject mob;
    MeshRenderer _meshRenderer;

    [SyncVar]
    Color playerColor;

    public override void OnStartClient()
    {
        base.OnStartClient();
        SetPlayerColor(playerColor);
    }

    [Server]
    public override void OnStartServer()
    {
        playerColor = GameManager.Instance.colors[GameManager.Instance.gameNetworkManager.playerCount - 1];
    }

    void SetPlayerColor(Color color)
    {
        mob = gameObject.transform.GetChild(0).gameObject;
        _meshRenderer = gameObject.GetComponent<MeshRenderer>();
        mob.GetComponent<P3dPaintDecal>().Color = color;
        _meshRenderer.material.color = color;
    }
}