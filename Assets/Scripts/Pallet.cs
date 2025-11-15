using UnityEngine;
using System.Collections.Generic;

public class Pallet : MonoBehaviour
{
    [Header("Свойства")]
    public Water water;
    public Glow glow;
    public Temp temp;
    [Header("Растения в зоне")]
    public List<Plant> plants = new List<Plant>();

    private void Start() {
        water = GetComponent<Water>();
        glow = GetComponent<Glow>();
        temp = GetComponent<Temp>();
    }
  
    private void OnTriggerEnter(Collider other) {
        Plant plant = other.GetComponent<Plant>();
        if (plant != null && !plants.Contains(plant)) {
            plants.Add(plant);
            plant.transform.SetParent(transform);

        }
    }
    private void OnTriggerExit(Collider other) {
        Plant plant = other.GetComponent<Plant>();
        if (plant != null) {
            plants.Remove(plant);
            plant.transform.SetParent(null);
        }
    }
}
