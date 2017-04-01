using UnityEngine;

public abstract class BonusBase : MonoBehaviour
{
    protected GameObject player;

    [Tooltip("Duration in seconds.")]
    public float duration = 0.0f;

    public virtual void ApplyBonus(GameObject player)
    {
        this.player = player;
    }
}
