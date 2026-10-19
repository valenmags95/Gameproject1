using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int currentDay = 1;

    public int activitySlotsPerDay = 1;
    public int activitySlotsRemaining = 1;

    void Start()
    {
        StartNewDay();
    }

    public bool CanPerformActivity()
    {
        return activitySlotsRemaining > 0;
    }

    public void UseActivitySlot()
    {
        if (!CanPerformActivity())
        {
            Debug.Log("No activity slots remaining!");
            return;
        }

        activitySlotsRemaining--;

        Debug.Log("Activity slots remaining: " + activitySlotsRemaining);

        if (activitySlotsRemaining == 0)
        {
            EndDay();
        }
    }

    void EndDay()
    {
        currentDay++;
        StartNewDay();
    }

    void StartNewDay()
    {
        activitySlotsRemaining = activitySlotsPerDay;

        Debug.Log("Day " + currentDay + " begins!");
        Debug.Log("Activity slots available: " + activitySlotsRemaining);
    }
}