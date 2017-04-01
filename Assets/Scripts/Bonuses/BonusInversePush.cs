using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusInversePush : BonusBase
{
    private void Awake()
    {
        Name = "Inversed Push";
    }

    public override void Activate(GameObject player)
    {
        base.Activate(player);
        if(this.player!=null)
            playerController.inversedPush = true;
    }

    public override void Deactivate()
    {
        if(player!=null)
            playerController.inversedPush = false;
        base.Deactivate();
    }
}
