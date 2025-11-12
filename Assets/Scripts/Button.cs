using UnityEngine;

public class Button : MonoBehaviour
{
    public bool isAction = true;

    private void Start()
    {

    }
    private
    void Update()
    {
        if (isAction)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
    public void switchActions()
    {
        this.isAction = !this.isAction;
    }
}
