using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BonusManager : MonoBehaviour
{
    public static BonusManager Instance { get; private set; }
    public float timeBetweenBonusesChange = 3.0f;
    private BonusBase currentBonus;
    private BonusBase currentBonus2;
    public GameObject[] bonusesPrefabs;
    public Randomizer randomizer;
    public Text bonusText;
    public float textDuration = 1.0f;

	private void Start ()
    {
        Instance = this;
        bonusText.text = "";
        InvokeRepeating("RandomizeBonuses", timeBetweenBonusesChange, timeBetweenBonusesChange);
	}

    private void RandomizeBonuses()
    {
        if (currentBonus != null)
            currentBonus.Deactivate();
        if (currentBonus2 != null)
            currentBonus2.Deactivate();
        int randomBonusId = Random.Range(0, bonusesPrefabs.Length);
        GameObject currentBonusObj = Instantiate(bonusesPrefabs[randomBonusId], transform);
        currentBonus = currentBonusObj.GetComponent<BonusBase>();
        Debug.Log(currentBonus.gameObject.name);
        StartCoroutine("ShowBonusText");
        switch (randomizer.playerSelected)
        {
            case Randomizer.PlayerSelection.Player1: currentBonus.Activate(GameController.Instance.Player1); break;
            case Randomizer.PlayerSelection.Player2: currentBonus.Activate(GameController.Instance.Player2); break;
            case Randomizer.PlayerSelection.Both:
                {
                    currentBonus.Activate(GameController.Instance.Player1);
                    //Create new bonus game object for second player
                    GameObject currentBonusObj2 = Instantiate(bonusesPrefabs[randomBonusId], transform);
                    currentBonus2 = currentBonusObj2.GetComponent<BonusBase>();
                    currentBonus2.Activate(GameController.Instance.Player2);
                }
                break;
        }
    }

    private IEnumerator ShowBonusText()
    {
        bonusText.text = currentBonus.Name;
        yield return new WaitForSeconds(textDuration);
        bonusText.text = "";
    }
}
