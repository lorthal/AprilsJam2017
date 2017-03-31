using UnityEngine;

public abstract class BonusBase : MonoBehaviour
{
    protected GameObject player;

    [Tooltip("Duration in seconds.")]
    public float duration = 0.0f;

    public abstract void ApplyBonus(GameObject player);
}
