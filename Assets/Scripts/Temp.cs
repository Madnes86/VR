using UnityEngine;

public class Temp : MonoBehaviour
{
    public int temp;
    public Temp link;

    void Start()
    {
        // link = GetComponent<Temp>();
    }

    void Update()
    {
        SetTemp();
    }

    public void SetTemp() {
        if (link != null) {
            this.temp = link.GetTemp();
        }
    }
    public int GetTemp() {
        return this.temp;
    }
}
