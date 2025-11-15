using UnityEngine;

public class Lamp : MonoBehaviour
{
    public bool isAction = false;
    public Button button;

    private void Start() {
        button?.onButton.AddListener(SetAction);
    }

    private void Update() {
        // SetAction();
    }

    private void SetAction(bool state) {
        this.isAction = state;
    }
}
