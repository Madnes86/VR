using UnityEngine;

public class Lamp : MonoBehaviour
{
    private GameObject lightObj;
    private Light lampLight;

    void Start()
    {
        lightObj = GameObject.Find("LightButton");
        lampLight = GetComponent<Light>();
    }

    void Update()
    {
        Button light = lightObj.GetComponent<Button>();
        if (light.isAction) {
            lampLight.color = Color.yellow;
        } else {
            lampLight.color = Color.black;
        }
    }
}
