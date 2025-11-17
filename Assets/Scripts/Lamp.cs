using UnityEngine;
using UnityEngine.UI;

public class Lamp : MonoBehaviour
{
    public bool isAction = false;
    public Toggle toggle;
    private Light light;

    private void Start() {
        toggle?.onValueChanged.AddListener(SetAction);
        light = GetComponent<Light>();
    }

    private void Update() {
        light.enabled = isAction;
    }

    public void SetAction(bool state) {
        this.isAction = state;
    }
    public void Toggle() {
        isAction = !isAction;
        Debug.Log(isAction);
    }
}
