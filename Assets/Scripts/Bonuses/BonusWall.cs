using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusWall : BonusBase
{
    public GameObject boxPrefab;
    private GameObject box;
    public float wallVerticalOffset = 1.0f;
    public float wallHorizontalOffset = 10.0f;

    private void Awake()
    {
        Name = "Wall";
    }

    public override void Activate(GameObject player)
    {
        base.Activate(player);
        if (this.player != null)
        {
            Vector3 boxPos = player.transform.position;
            boxPos.y += wallVerticalOffset;
            boxPos.z += wallHorizontalOffset;
            box = Instantiate(boxPrefab, boxPos, player.transform.rotation);
        }
    }

    public override void Deactivate()
    {
        if(player!=null)
            Destroy(box);
        base.Deactivate();
    }
}
