using UnityEngine;
using UnityEngine.UI;
using static TimeManager;

public class BarManager : MonoBehaviour
{
    public static BarManager instance;
    public Image thirstBar;
    public float thirst = 100f;
    public float currentThirst;
    public Image hungerBar;
    public float hunger = 100f;
    public float currentHunger;

    public delegate void Thirsty();
    public static event Thirsty ImThirst;
    public delegate void Hungry();
    public static event Hungry ImHungry;
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
        currentThirst = thirst;
        UpdateThirstBar();
        UpdateHungerBar();
    }

    public void MoreThirst(float value)
    {
        currentThirst -= value;
        UpdateThirstBar();
    }
    public void MoreHunger(float value)
    {
        currentHunger -= value;
        UpdateHungerBar();
    }
    public void LessThirst(float value)
    {
        currentThirst += value;
        UpdateThirstBar();
    }
    public void LessHunger(float value)
    {
        currentHunger += value;
        UpdateHungerBar();
    }

    void UpdateThirstBar()
    {
        float thirstPercentage = currentThirst / thirst;
        thirstBar.fillAmount = thirstPercentage;
        //Debug.Log(hungerPercentage);
        if (thirstPercentage<0.25) {
            ImThirst();
        }else if (thirstPercentage > 1)
        {           
            GoWork();
        }
    }
    void UpdateHungerBar()
    {
        float hungerPercentage = currentHunger / hunger;
        hungerBar.fillAmount = hungerPercentage;
        //Debug.Log(hungerPercentage);
        if (hungerPercentage < 0.25)
        {
            ImHungry();
        }
        else if (hungerPercentage > 1)
        {
            GoWork();
        }
    }

}