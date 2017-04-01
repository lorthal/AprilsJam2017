using UnityEngine;

public abstract class BonusBase : MonoBehaviour
{
    protected GameObject player;
    protected PlayerController playerController;
    public string Name { get; protected set; }
    public Material bonusIconMaterial;

    public virtual void Activate(GameObject player)
    {
        this.player = player;
        if(this.player!=null)
            playerController = player.GetComponent<PlayerController>();
    }

    public virtual void Deactivate()
    {
        Destroy(gameObject);
    }
}
