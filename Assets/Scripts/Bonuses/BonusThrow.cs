using UnityEngine;

public class BonusThrow : BonusBase
{
    float throwForce = 10.0f;

    public override void Activate(GameObject player)
    {
        base.Activate(player);
        if(player!=null)
            playerController.Rb.AddForce((player.transform.forward + player.transform.up) * throwForce, ForceMode.Impulse);
    }

    public override void Deactivate()
    {
        base.Deactivate();
    }
}
