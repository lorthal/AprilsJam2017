using UnityEngine;

public abstract class BonusBase : MonoBehaviour
{
    protected GameObject player;
    public string Name { get; protected set; }

    public virtual void Activate(GameObject player)
    {
        this.player = player;
    }

    public virtual void Deactivate()
    {
        Destroy(gameObject);
    }
}
