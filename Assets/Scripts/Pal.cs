using UnityEngine;

public class Pal : MonoBehaviour
{
    public GameObject[] plants = new GameObject[4];
    private int MAX_PLANTS = 4;

    public bool AddPot(GameObject plant) {
        for (int i = 0; i < plants.Length; i++)
        {
            if (plants[i] == null)
            {
                plants[i] = plant;
                setPosition(plant, i);
                Debug.Log($"Горшочек добавлен в слот {i + 1}/{MAX_PLANTS}");
                return true;
            }
        }
        
        Debug.Log("Поддон полон! Нельзя добавить больше горшочков");
        return false;
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name.Contains("Plant")) {
            AddPot(other.gameObject);
        }
    }
    private void setPosition(GameObject plant, int i) {
        Vector3[] positions = {
            new Vector3(0.3f, 0, 0.3f),
            new Vector3(0.3f, 0, 0.3f),
            new Vector3(0.3f, 0, 0.3f),
            new Vector3(0.3f, 0, 0.3f)
        };
        plant.transform.position = transform.position + positions[i];
        plant.transform.SetParent(transform);
    }
}
