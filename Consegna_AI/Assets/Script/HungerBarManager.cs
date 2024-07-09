using UnityEngine;
using UnityEngine.UI;

public class HungerBarManager : MonoBehaviour
{
    public static HungerBarManager instance;
    public Image hungerBar;
    public float hunger = 100f;
    public float currentHunger;

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

    void UpdateHungerBar()
    {
        float healthPercentage = currentHunger / hunger;
        hungerBar.fillAmount = healthPercentage;
    }
}