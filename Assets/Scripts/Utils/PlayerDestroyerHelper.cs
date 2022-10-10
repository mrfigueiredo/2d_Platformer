using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyerHelper : MonoBehaviour
{
    public Player player;

    private void Awake()
    {
        if(player == null)
        {
            player = GetComponentInParent<Player>();
        }
    }

    public void DestroyPlayer()
    {
        player.DestroyMe();
    }
}
