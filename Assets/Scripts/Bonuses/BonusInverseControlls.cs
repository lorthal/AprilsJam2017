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
        playerController.inversedControlls = true;
    }

    public override void Deactivate()
    {
        playerController.inversedControlls = false;
        base.Deactivate();
    }
}
