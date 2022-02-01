using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorySkip : MonoBehaviour
{
    // Start is called before the first frame update public void Skip()
    public void skipstory()
    {
        SceneManager.LoadScene("Main Platform");
    }
}
