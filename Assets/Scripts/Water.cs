using UnityEngine;

public class Water : MonoBehaviour
{
    public int water = 0;
    public int MAX_WATER = 16;
    public Water link;
    private Transform view;
    protected float time = 0f;
    protected float interval = 1f;
    private float MAX_HEIGHT;

    void Start()
    {
        view = transform.Find("Water");
        MAX_HEIGHT = view.localScale.y;
        View();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= interval) {
            SetWater();
            View();
            time = 0;
        }
    }
    public void SetWater() {
        if (link != null 
        && MAX_WATER > water 
        && link.GetWater()) {
            water++;
        }
    }
    public virtual bool GetWater() {
        if (this.water > 0) {
            water--;
            return true;
        } else {
            return false;
        }
    }
    private void View() {
        float ratio = (float)water / MAX_WATER;
        float height = MAX_HEIGHT * ratio;
        Vector3 scale = view.localScale;
        scale.y = height;
        view.localScale = scale;
        view.gameObject.SetActive(water > 0);
    }
}
