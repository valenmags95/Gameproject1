using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int health = 80;
    public int energy = 70;
    public int happiness = 60;
    public int intelligence = 55;
    public int socialLife = 40;

    // Temporary activity system
    public int activitySlotsPerDay = 1;
    public int activitySlotsRemaining = 1;

    void Start()
    {
        Debug.Log("Character created!");
        PrintStats();
    }

    public void Study()
    {
        if (!CanPerformActivity()) return;

        energy -= 15;
        intelligence += 5;

        ConsumeActivitySlot();
        ClampStats();

        Debug.Log("You studied.");
        PrintStats();
    }

    public void Rest()
    {
        if (!CanPerformActivity()) return;

        health += 3;
        energy += 20;

        ConsumeActivitySlot();
        ClampStats();

        Debug.Log("You rested.");
        PrintStats();
    }

    public void Exercise()
    {
        if (!CanPerformActivity()) return;

        health += 5;
        energy -= 20;

        ConsumeActivitySlot();
        ClampStats();

        Debug.Log("You exercised.");
        PrintStats();
    }

    bool CanPerformActivity()
    {
        if (activitySlotsRemaining <= 0)
        {
            Debug.Log("No activity slots remaining today!");
            return false;
        }

        return true;
    }

    void ConsumeActivitySlot()
    {
        activitySlotsRemaining--;
        Debug.Log("Activity slots remaining: " + activitySlotsRemaining);
    }

    void ClampStats()
    {
        health = Mathf.Clamp(health, 0, 100);
        energy = Mathf.Clamp(energy, 0, 100);
        happiness = Mathf.Clamp(happiness, 0, 100);
        intelligence = Mathf.Clamp(intelligence, 0, 100);
        socialLife = Mathf.Clamp(socialLife, 0, 100);
    }

    void PrintStats()
    {
        Debug.Log("Health: " + health);
        Debug.Log("Energy: " + energy);
        Debug.Log("Happiness: " + happiness);
        Debug.Log("Intelligence: " + intelligence);
        Debug.Log("Social Life: " + socialLife);
    }
}