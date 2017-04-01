using UnityEngine;

public class BonusReplace : BonusBase
{
    private void Awake()
    {
        Name = "Replace Players";
    }

    public override void Activate(GameObject player)
    {
        Vector3 firstPlayerPosition = GameController.Instance.Player1.transform.position;
        Vector3 secondPlayerPosition = GameController.Instance.Player2.transform.position;

        GameController.Instance.Player1.transform.position = secondPlayerPosition;
        GameController.Instance.Player2.transform.position = firstPlayerPosition;
    }
}
