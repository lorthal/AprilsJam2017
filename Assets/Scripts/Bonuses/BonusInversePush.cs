using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusInversePush : BonusBase
{
    private PlayerController playerController;

    private void Awake()
    {
        Name = "Inversed Push";
    }

    public override void Activate(GameObject player)
    {
        base.Activate(player);
        playerController = player.GetComponent<PlayerController>();
        playerController.inversedPush = true;
    }

    public override void Deactivate()
    {
        playerController.inversedPush = false;
        base.Deactivate();
    }
}
