using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyNetworkPlayer : NetworkBehaviour
{
    [SyncVar(hook =nameof(handleDisplayName))]
    [SerializeField]
    private string displayName="Player X";

    [SyncVar(hook =nameof(handleDisplayColor))]
    [SerializeField]
    private Color playerColor=Color.black;

    [SerializeField] private Renderer playerRenderer=null;
    [SerializeField] private TMP_Text playerShowDisplayName=null;

    [Server]
    public void setDisplayName(string name) { 
        this.displayName = name;
    }


    [Server]
    public void setPlayerColor(Color color)
    {
        this.playerColor = color;
    }

    private void handleDisplayColor(Color oldColor, Color newColor) {

        playerRenderer.material.SetColor("_BaseColor", newColor);
    }

    private void handleDisplayName(string oldName, string newName)
    {

        playerShowDisplayName.text = newName;
    }
}
