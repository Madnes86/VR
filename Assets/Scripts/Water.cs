using UnityEngine;

public class Water : MonoBehaviour
{
    public int water = 0;
    public int MAX_WATER = 16;
    public Water link;
    // private GameObject waterObj;
    protected float time = 0f;
    protected float interval = 1f;
    private float MAX_HEIGHT;
    private float height;

    void Start()
    {
        // this.waterObj = transform.Find("Water")?.gameObject;
        // if (waterObj == null) {
        //     enabled = false;
        //     return;
        // }
        this.MAX_HEIGHT = 0.000104f;
        // View();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= interval) {
            SetWater();
            // this.waterObj.SetActive(water > 0);
            time = 0;

        }
    }
    public void SetWater() {
        if (this.link != null 
        && this.MAX_WATER > this.water 
        && this.link.GetWater()) {
            water++;
            // View();
        }
    }
    // private void View() {
    //     height = MAX_HEIGHT / (float)water;
    //     Vector3 newScale = waterObj.transform.localScale;
    //     newScale.y = height;
    //     waterObj.transform.localScale = newScale;
    // }
    public virtual bool GetWater() {
        if (this.water > 0) {
            water--;
            return true;
        } else {
            return false;
        }
    }
}
