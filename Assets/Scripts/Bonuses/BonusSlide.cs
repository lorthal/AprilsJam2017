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
        playerController.SlideControlls = true;
    }

    public override void Deactivate()
    {
        playerController.SlideControlls = false;
        base.Deactivate();
    }
}
