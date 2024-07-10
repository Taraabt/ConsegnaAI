using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;
    public delegate void NightTime();
    public static event NightTime ItsNight;
    public delegate void DayTime();
    public static event DayTime ItsDay;
    bool itsDay;
    bool itsNight;
    float currentTime;

    [SerializeField]float time;
    [SerializeField] TMP_Text text;
    [SerializeField]float multiplyier;

    private void Start()
    {
        currentTime=0;
        multiplyier = time / 24;
    }
    void Update()
    {
        currentTime = currentTime + Time.deltaTime;
        
        text.text=Mathf.Round(currentTime/multiplyier).ToString(); 


        if (currentTime>=time/24*8&&!itsDay)
        {
            itsNight = false;
            itsDay = true;
            ItsDay();
        }
        else if(currentTime>=time/24*23 &&!itsNight){
            currentTime = 0;
            itsNight = true;
            itsDay = false;
            ItsNight();
        }
    }
}
