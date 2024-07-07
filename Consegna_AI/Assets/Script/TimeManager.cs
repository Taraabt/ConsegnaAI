using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;
    public delegate void NightTime();
    public static event NightTime ItsNight;
    public delegate void DayTime();
    public static event DayTime ItsDay;
    bool itsDay = true;
    bool itsNight = false;

    [SerializeField]float time;
    float currentTime;

    private void Start()
    {
        currentTime=time;
    }
    void Update()
    {
        currentTime = currentTime - Time.deltaTime;
        Debug.Log(currentTime);
        if (currentTime<=0&&!itsDay)
        {
            itsNight = false;
            itsDay = true;
            currentTime =time;
            ItsDay();
        }
        else if(currentTime<=time/24*8&&!itsNight){
            itsNight = true;
            itsDay = false;
            ItsNight();
        }
    }
}
