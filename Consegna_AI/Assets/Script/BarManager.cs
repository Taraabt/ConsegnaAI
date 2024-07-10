using UnityEngine;
using UnityEngine.UI;
using static TimeManager;

public class BarManager : MonoBehaviour
{
    public static BarManager instance;
    public Image hungerBar;
    public float hunger = 100f;
    public float currentHunger;
    public delegate void Thirsty();
    public static event Thirsty ImThirst;
    public delegate void ItsOk();
    public static event ItsOk GoWork;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        currentHunger = hunger;
        UpdateHungerBar();
    }

    public void MoreHungry(float value)
    {
        currentHunger -= value;
        UpdateHungerBar();
    }
    public void LessHungry(float value)
    {
        currentHunger += value;
        UpdateHungerBar();
    }

    void UpdateHungerBar()
    {
        float hungerPercentage = currentHunger / hunger;
        hungerBar.fillAmount = hungerPercentage;
        //Debug.Log(hungerPercentage);
        if (hungerPercentage<0.25) {
            ImThirst();
        }else if (hungerPercentage > 1)
        {
            GoWork();
        }
    }
}