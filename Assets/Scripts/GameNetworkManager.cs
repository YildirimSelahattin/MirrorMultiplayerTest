using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameNetworkManager : NetworkManager
{
    public Transform leftRacketSpawn;
    public Transform rightRacketSpawn;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        // add player at correct spawn position
        Transform start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
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
