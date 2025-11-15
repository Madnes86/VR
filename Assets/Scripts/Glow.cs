using UnityEngine;

public class Glow : MonoBehaviour
{
    public bool isGlow = false;
    public Glow link;

    void Start()
    {
        // link = GetComponent<Glow>();
    }

    void Update()
    {
        SetGlow();
    }
    
    public void SetGlow() {
        if (link != null) {
            this.isGlow = link.GetGlow();
        }
    }
    public bool GetGlow() {
        return this.isGlow;
    }
}
