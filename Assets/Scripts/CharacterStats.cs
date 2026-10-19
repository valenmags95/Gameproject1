
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int health = 80;
    public int energy = 70;
    public int happiness = 60;
    public int intelligence = 55;
    public int socialLife = 40;

    void Start()
    {
        Debug.Log("Character created!");
        Debug.Log("Health: " + health);
        Debug.Log("Energy: " + energy);
        Debug.Log("Happiness: " + happiness);
        Debug.Log("Intelligence: " + intelligence);
        Debug.Log("Social Life: " + socialLife);
    }
}