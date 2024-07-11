using UnityEngine;
using UnityEngine.UI;
using static TimeManager;

public class BarManager : MonoBehaviour
{
    public static BarManager instance;
    public Image thirstBar;
    public float thirst = 100f;
    public float currentThirst;
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
        currentThirst = thirst;
        UpdateThirstBar();
    }

    public void MoreThirst(float value)
    {
        currentThirst -= value;
        UpdateThirstBar();
    }
    public void LessThirst(float value)
    {
        currentThirst += value;
        UpdateThirstBar();
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

}