using UnityEngine;

public class Pump : Water
{
    public bool isAction = false;

    void Start()
    {
        this.MAX_WATER = 72;
        this.water = 72;
        // this.time = 0;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= interval) {
            SetWater();
            time = 0;
        }
    }
    public override bool GetWater() {
        return isAction && base.GetWater();
    }

    public void Refill() {
        this.water = 72;
    }

    public void SetAction(bool state) {
        this.isAction = state;
    }
}
