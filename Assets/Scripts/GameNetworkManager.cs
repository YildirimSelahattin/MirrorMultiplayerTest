using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameNetworkManager : NetworkManager
{
    public Transform baseSpawnPoint;
    Transform start;
    //public int playerCount; == numplayers

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        // add player at correct spawn position
        if (numPlayers % 2 == 0)
        {
            baseSpawnPoint.position = new Vector3(baseSpawnPoint.position.x - 1.5f, baseSpawnPoint.position.y, baseSpawnPoint.position.z);
            start = baseSpawnPoint;
        }
        else
        {
            baseSpawnPoint.position = new Vector3(baseSpawnPoint.position.x + 1.5f, baseSpawnPoint.position.y, baseSpawnPoint.position.z);
            start = baseSpawnPoint;
        }

        GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        NetworkServer.AddPlayerForConnection(conn, player);

        //Debug.Log(conn.identity.netId);
        //1'den baslayarak numaralandırır

        if (numPlayers == 2)
        {

        }
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        // call base functionality (actually destroys the player)
        base.OnServerDisconnect(conn);
    }
}
