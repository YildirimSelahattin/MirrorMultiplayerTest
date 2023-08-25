using System.Collections;
using System.Collections.Generic;
using Mirror;
using Mirror.Examples.Basic;
using PaintIn3D;
using UnityEngine;

public class PlayerManager : NetworkBehaviour
{
    GameObject mob;
    MeshRenderer _meshRenderer;

    void Start()
    {
        if (!isLocalPlayer) return;
        mob = gameObject.transform.GetChild(0).gameObject;
        _meshRenderer = gameObject.GetComponent<MeshRenderer>();
        Debug.LogError(GameManager.Instance.gameNetworkManager.playerCount);
        Debug.LogError(GameManager.Instance.colors[GameManager.Instance.gameNetworkManager.playerCount]);
        mob.GetComponent<P3dPaintDecal>().Color = GameManager.Instance.colors[GameManager.Instance.gameNetworkManager.playerCount];
        _meshRenderer.material.color = GameManager.Instance.colors[GameManager.Instance.gameNetworkManager.playerCount];
        
    }
}