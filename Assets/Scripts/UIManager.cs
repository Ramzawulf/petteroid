using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public ResourceBar HungerBar;
    public ResourceBar HealthBar;
    public ResourceBar HappinessBar;
    public ResourceBar EnergyBar;

    public Text NameLabel;
    public Text AgeLabel;

    void Start()
    {
        HungerBar.MaxValue = PetBehaviour.Instance.MaxHappiness;
        HungerBar.CurrentValue = PetBehaviour.Instance.CurrentHunger;

        HealthBar.MaxValue = PetBehaviour.Instance.MaxHealth;
        HealthBar.CurrentValue = PetBehaviour.Instance.CurrentHealth;

        HappinessBar.MaxValue = PetBehaviour.Instance.MaxHappiness;
        HappinessBar.CurrentValue = PetBehaviour.Instance.CurrentHappiness;

        EnergyBar.MaxValue = PetBehaviour.Instance.MaxEnergy;
        EnergyBar.CurrentValue = PetBehaviour.Instance.CurrentEnergy;

        NameLabel.text = PetBehaviour.Instance.PetName;
        AgeLabel.text = PetBehaviour.Instance.Age.ToString();

    }

    void Update()
    {
        HungerBar.CurrentValue = PetBehaviour.Instance.CurrentHunger;
        HealthBar.CurrentValue = PetBehaviour.Instance.CurrentHealth;
        HappinessBar.CurrentValue = PetBehaviour.Instance.CurrentHappiness;
        EnergyBar.CurrentValue = PetBehaviour.Instance.CurrentEnergy;
    }
}
