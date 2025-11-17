using UnityEngine;

public class Plant : MonoBehaviour
{
    [Header("Настройкт")]
    public bool isRefresh = true;
    [Header("Стадии")]
    public int STAGE_1 = 3;
    public int STAGE_2 = 6;
    public int STAGE_3 = 8;
    [Header("Среда")]
    public int MIN_TEMP = 10;
    public int MAX_TEMP = 30;
    private float height = 1;
    private float scaleHeight;
    private int MAX_HEIGHT = 30;
    private int stage = 0;
    private int TIME_RIPE = 2;
    private int ripeTime = 0;
    private int rot = 0;
    private float time = 0f;
    private float interval = 2f;
    private Water water;
    private Glow glow;
    private Temp temp;
    private Transform ground;
    private Transform sids;
    private Transform trunk;
    private Transform leaf;
    private Transform ripe;

    void Start()
    {
        GetParentComponent();
        ground = transform.Find("Ground");
        sids = transform.Find("Sids");
        trunk = transform.Find("Trunk");
        scaleHeight = trunk.localScale.y;
        leaf = transform.Find("Leaf");
        ripe = transform.Find("Ripe");
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= interval) {
            SetStage();
            time = 0;
        }
    }
    private void SetStage() {
        if (rot > 4) {
            Destroy(gameObject);
        }
        if (IsValidate()) {
            this.stage++;
            ViewWater();

            if (STAGE_1 > stage) {

                trunk?.gameObject.SetActive(false);
                sids?.gameObject.SetActive(true);

            } else if (STAGE_2 > stage) {

                sids?.gameObject.SetActive(false);
                trunk?.gameObject.SetActive(true);
                ViewHeight();
                
            } else if (STAGE_3 > stage) {

                ViewRipe(false);

            } else if (STAGE_3 + TIME_RIPE > stage) {

                ViewRipe(true);

            } else {
                if (isRefresh) {
                    stage = STAGE_1;
                } else {
                    Destroy(gameObject);
                }
            }
            if (rot > 0) {
                rot--;
            }
        } else {
            rot++;
        }
        Debug.Log($"Plant stage: {stage}, Ripe: {ripeTime}");
    }

    private void ViewHeight() {
        if (MAX_HEIGHT > height) { 
            height += (float)MAX_HEIGHT / (STAGE_2 - STAGE_1);
            float scale = Mathf.Lerp(scaleHeight / MAX_HEIGHT, scaleHeight, (float)height / MAX_HEIGHT);
            trunk.localScale = new Vector3(scale, scale, scale);
        }
    }
    private bool IsValidate() {
        return ViewGlow() 
            && ViewWater()
            && temp?.GetTemp() is float tempVal && tempVal > MIN_TEMP && tempVal < MAX_TEMP;
    }
    void SetColor(Renderer renderer, Color color) => renderer.material.color = color;
    private bool ViewWater() {
        Renderer groundRenderer = ground?.GetComponent<Renderer>();
        if (water.water > 3) {
            SetColor(groundRenderer, Color.black);
            return false;
        } else if (!water.GetWater()) {
            SetColor(groundRenderer, Color.yellow);
            return false;
        }
        SetColor(groundRenderer, Color.green);
        return true;
    }
    private bool ViewGlow() {
        Renderer leafRenderer = leaf?.GetComponent<Renderer>();
        if (!glow.GetGlow()) {
            SetColor(leafRenderer, Color.yellow);
            return false;
        }
        SetColor(leafRenderer, Color.green);
        return true;
    }
    private bool ViewTemp() {
        Renderer trunkRenderer = trunk?.GetComponent<Renderer>();
        if (MIN_TEMP > temp.GetTemp()) {
            SetColor(trunkRenderer, Color.yellow);
            return false;
        } else if (temp.GetTemp() > MAX_TEMP) {
            SetColor(trunkRenderer, Color.yellow);
            return false;
        }
        SetColor(trunkRenderer, Color.green);
        return true;
    }
    private void ViewRipe(bool isRipe) {
        ripe?.gameObject.SetActive(true);
        Renderer ripeRenderer = ripe?.GetComponent<Renderer>();
        if (isRipe) {
            SetColor(ripeRenderer, Color.red);
        } else {
            SetColor(ripeRenderer, Color.green);
        }
    }
    public bool GetRipe() {
        if (ripeTime > 0) {
            ripe?.gameObject.SetActive(false);
            ripeTime = 0;
            return true;
        } else {
            return false;
        }
    }
    private void OnTransformParentChanged() {
        GetParentComponent();
    }
    private void GetParentComponent() {
        water = transform.parent?.GetComponent<Water>();
        glow = transform.parent?.GetComponent<Glow>();
        temp = transform.parent?.GetComponent<Temp>();
    }
}
