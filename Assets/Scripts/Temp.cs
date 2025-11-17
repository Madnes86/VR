using UnityEngine;

public class Temp : MonoBehaviour
{
    public float temp;
    public Temp link;

    void Start()
    {
        // link = GetComponent<Temp>();
    }

    void Update()
    {
        // SetTemp();
    }

    public void SetTemp(float value) {
        temp = value;
        Debug.Log($"test {value}");
        // if (link != null) {
        //     this.temp = link.GetTemp();
        // }
    }
    public float GetTemp() {
        return temp;
    }
}
