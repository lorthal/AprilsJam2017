using UnityEngine;

public class BonusSlide : BonusBase
{
    private PlayerController playerController;
    public float slideSpeed = 10.0f;

    private void Awake()
    {
        Name = "Slide";
    }

    public override void Activate(GameObject player)
    {
        base.Activate(player);
        playerController = player.GetComponent<PlayerController>();
        playerController.SlideControlls = true;
    }

    public override void Deactivate()
    {
        playerController.SlideControlls = false;
        base.Deactivate();
    }
}
