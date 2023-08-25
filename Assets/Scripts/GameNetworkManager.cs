using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameNetworkManager : NetworkManager
{
    public GameNetworkManager Instance;
    public Transform baseSpawnPoint;
    Transform start;
    public int playerCount;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        playerCount = numPlayers;
        // add player at correct spawn position
        if (numPlayers % 2 == 0)
        {
            baseSpawnPoint.position = new Vector3(baseSpawnPoint.position.x - (2 * numPlayers + 1), baseSpawnPoint.position.y, baseSpawnPoint.position.z);
            start = baseSpawnPoint;
            Debug.Log(0 + "numPlayers" + numPlayers);
        }
        else
        {
            Debug.Log(1 + "numPlayers" + numPlayers);
            baseSpawnPoint.position = new Vector3(baseSpawnPoint.position.x + (2 * numPlayers + 1), baseSpawnPoint.position.y, baseSpawnPoint.position.z);
            start = baseSpawnPoint;
        }

        GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        NetworkServer.AddPlayerForConnection(conn, player);

        //Debug.Log(conn.identity.netId);
        //0'den baslayarak numaralandırır

        if (numPlayers == 4)
        {

        }
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        // call base functionality (actually destroys the player)
        base.OnServerDisconnect(conn);
    }
}