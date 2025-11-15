using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public bool isAction = true;
    // public Lamp link;
    // [System.Serializable]
    public UnityEvent<bool> onButton;

    private void Update()
    {
        GetComponent<Renderer>().material.color = isAction ? Color.green : Color.red;
        onButton?.Invoke(this.isAction);
    }
    // public bool GetAction() {
    //     return this.isAction;
    // }
}
