using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreNumberScript : MonoBehaviour
{
    private TextMesh score_Text;
    // Start is called before the first frame update
    void Start()
    {
        score_Text = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setScore(int score)
    {
        score_Text.text = score.ToString();
    }
}
