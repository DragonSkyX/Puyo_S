using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    /*Utilizado para controlar a UI e os Parametro do jogo */
    private int level=0;
    private int score=0;
    Text ScoreTXT;
    Text LevelTXT;

    public int Level {
        get { return level; }
        set { level = value;
            LevelTXT.text = level.ToString();

        }

    }


    public int Score
    {
        get { return score; }
        set { score = value;
            ScoreTXT.text = score.ToString();   
        }

    }

    void Start()
    {

        ScoreTXT = GameObject.Find("Score").GetComponent<Text>();
        LevelTXT = GameObject.Find("Level").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
