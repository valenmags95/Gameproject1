using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int health = 80;
    public int energy = 70;
    public int happiness = 60;
    public int intelligence = 55;
    public int socialLife = 40;

    public TurnManager turnManager;

    void Start()
    {
        Debug.Log("Character created!");
        PrintStats();
    }

public void Study()
{
    if (!CanPerformActivity(15)) return;

    energy -= 15;
    intelligence += 5;

    ConsumeActivitySlot();
    ClampStats();

    Debug.Log("You studied.");
    PrintStats();
}

public void Rest()
{
    if (!CanPerformActivity(0)) return;

    health += 3;
    energy += 20;

    ConsumeActivitySlot();
    ClampStats();

    Debug.Log("You rested.");
    PrintStats();
}

public void Exercise()
{
    if (!CanPerformActivity(20)) return;

    health += 5;
    energy -= 20;

    ConsumeActivitySlot();
    ClampStats();

    Debug.Log("You exercised.");
    PrintStats();
}

bool CanPerformActivity(int requiredEnergy)
{
    if (turnManager == null)
    {
        Debug.LogError("TurnManager has not been assigned!");
        return false;
    }

    if (!turnManager.CanPerformActivity())
    {
        Debug.Log("No activity slots remaining today!");
        return false;
    }

    if (energy < requiredEnergy)
    {
        Debug.Log("Not enough energy! You need at least "
                  + requiredEnergy + " energy.");
        return false;
    }

    return true;
}
    void ConsumeActivitySlot()
    {
        turnManager.UseActivitySlot();
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