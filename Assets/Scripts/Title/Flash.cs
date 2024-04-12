using UnityEngine;
using UnityEngine.UI;

public class Flash :MonoBehaviour
{
    [SerializeField] Type type;
    float timer = 0;
    Color color;
    enum Type
    {
        Bar,
        Text,
    }
    private void Start()
    {
        if (type == Type.Bar)
        {
            color = GetComponent<Image>().color;
        }
        if (type == Type.Text)
        {
            color = GetComponent<Text>().color;
        }
    }
    private void Update()
    {
        timer += Time.deltaTime;
        color.a = Mathf.Abs(Mathf.Sin(timer));
        if (type == Type.Bar)
        {
            GetComponent<Image>().color = color;
        }
        if (type == Type.Text)
        {
            GetComponent<Text>().color = color;
        }
    }
}
