using UnityEngine;

public class BonusInverseControlls : BonusBase
{
    private void Awake()
    {
        Name = "Inverse Controls";
    }

    public override void Activate(GameObject player)
    {
        base.Activate(player);
        if(this.player!=null)
            playerController.inversedControlls = true;
    }

    public override void Deactivate()
    {
        if(player!=null)
            playerController.inversedControlls = false;
        base.Deactivate();
    }
}
