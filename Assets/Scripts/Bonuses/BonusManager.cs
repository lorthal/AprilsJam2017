using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BonusManager : MonoBehaviour
{
    public static BonusManager Instance { get; private set; }
    private BonusBase currentBonus;
    private BonusBase currentBonus2;
    public GameObject[] bonusesPrefabs;
    public GameObject bonusIcon;
    public float bonusIconStayTime = 1.0f;
    private Quaternion bonusIconStayRotation;

	private void Start ()
    {
        Instance = this;
        bonusIconStayRotation = bonusIcon.transform.rotation;
        InvokeRepeating("RotateBonusIcon", 0.0f, Time.fixedDeltaTime);
    }

    public void RandomizeBonuses(Randomizer.PlayerSelection playerSelected)
    {
        CancelInvoke("RotateBonusIcon");
        
        bonusIcon.transform.rotation = bonusIconStayRotation;
        if (currentBonus != null)
            currentBonus.Deactivate();
        if (currentBonus2 != null)
            currentBonus2.Deactivate();
        int randomBonusId = Random.Range(0, bonusesPrefabs.Length);
        GameObject currentBonusObj = Instantiate(bonusesPrefabs[randomBonusId], transform);
        currentBonus = currentBonusObj.GetComponent<BonusBase>();
        bonusIcon.GetComponentInChildren<Renderer>().material = currentBonus.bonusIconMaterial;
        bonusIcon.GetComponentInChildren<ParticleSystem>().Play();
        StartCoroutine("StartRotatingBonusIconWithDelay");
        switch (playerSelected)
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

    private void RotateBonusIcon()
    {
        bonusIcon.transform.Rotate(180.0f * Time.fixedDeltaTime, 0.0f, 0.0f);
    }

    private IEnumerator StartRotatingBonusIconWithDelay()
    {
        yield return new WaitForSeconds(bonusIconStayTime);
        InvokeRepeating("RotateBonusIcon", 0.0f, Time.fixedDeltaTime);
    }
}
