using UnityEngine;

public abstract class BonusBase : MonoBehaviour
{
    protected GameObject player;
    protected PlayerController playerController;
    public string Name { get; protected set; }
    public Texture bonusIconTexture;

    public virtual void Activate(GameObject player)
    {
        this.player = player;
        playerController = player.GetComponent<PlayerController>();
    }

    public virtual void Deactivate()
    {
        Destroy(gameObject);
    }
}
