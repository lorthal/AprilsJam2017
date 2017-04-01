using UnityEngine;

public class BonusSlide : BonusBase
{
    public float slideSpeed = 10.0f;

    private void Awake()
    {
        Name = "Slide";
    }

    public override void Activate(GameObject player)
    {
        base.Activate(player);
        if(this.player != null)
            playerController.SlideControlls = true;
    }

    public override void Deactivate()
    {
        if(player != null)
            playerController.SlideControlls = false;
        base.Deactivate();
    }
}
