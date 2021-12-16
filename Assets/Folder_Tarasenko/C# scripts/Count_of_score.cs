using UnityEngine;
using UnityEngine.UI;


public class Count_of_score : MonoBehaviour
{
    public float Score = 0;
    public Text Score_text;
    public int tm = 0;
    public Rigidbody2D rb;
    void Start()
    {
        Score_text.text = "Score: 0";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Score += rb.velocity.x * Time.deltaTime;
        Score_text.text = "Score: " + ((int)Score / 10).ToString();
    }

    public int ScoreReturn()
    {
        return (int)Score / 10;
    }
}
