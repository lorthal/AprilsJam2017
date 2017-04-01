using System.Collections;
using UnityEngine;

public class BonusInverseControlls : BonusBase
{
    private PlayerController playerController;

    public override void ApplyBonus(GameObject player)
    {
        base.ApplyBonus(player);
        playerController = player.GetComponent<PlayerController>();
        StartCoroutine("InverseControllsForSeconds");
    }

    private IEnumerator InverseControllsForSeconds()
    {
        playerController.inversedControlls = true;
        yield return new WaitForSeconds(duration);
        playerController.inversedControlls = false;
        Destroy(gameObject);
    }
}
