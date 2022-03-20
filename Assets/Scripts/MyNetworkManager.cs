using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyNetworkManager : NetworkManager
{
    [System.Obsolete]
    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        Debug.Log("Connected to a server");
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);

        MyNetworkPlayer player = conn.identity.GetComponent<MyNetworkPlayer>();
        player.setDisplayName($"Player {numPlayers}");
        player.setPlayerColor(new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));

        Debug.Log($"There are {numPlayers} number of players");
    }


}

