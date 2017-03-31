using System.Collections;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    public BonusManager Instance { get; private set; }
    public float timeBetweenBonusesChange = 3.0f;
    private BonusBase currentBonus;
    public GameObject[] bonusesPrefabs;
    public Randomizer randomizer;

	private void Start ()
    {
        Instance = this;
        InvokeRepeating("RandomizeBonuses", timeBetweenBonusesChange, timeBetweenBonusesChange);
	}

    private void RandomizeBonuses()
    {
        int randomBonusId = Random.Range(0, bonusesPrefabs.Length);
        GameObject currentBonusObj = Instantiate(bonusesPrefabs[randomBonusId], transform);
        currentBonus = currentBonusObj.GetComponent<BonusBase>();
        Debug.Log(currentBonus.gameObject.name);
        switch (randomizer.playerSelected)
        {
            case Randomizer.PlayerSelection.Player1: currentBonus.ApplyBonus(GameController.Instance.Player1); break;
            case Randomizer.PlayerSelection.Player2: currentBonus.ApplyBonus(GameController.Instance.Player2); break;
            case Randomizer.PlayerSelection.Both:
                {
                    currentBonus.ApplyBonus(GameController.Instance.Player1);
                    currentBonus.ApplyBonus(GameController.Instance.Player2);
                }
                break;
        }
    }
}
