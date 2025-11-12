using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public int y = 1;
    void Start()
    {
        // Debug.Log("test");
        // this.transform.position = new Vector3(0, 3, 0);
    }

    void Update()
    {
        Move();
    }
    private void Move()
    {
        GameObject buttonObj = GameObject.Find("Button");
        Button button = buttonObj.GetComponent<Button>();
        if (button.isAction)
        {
            this.transform.Translate(0, y, 0);
        }
    }
}
