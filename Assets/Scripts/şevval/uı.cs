using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uı : testere
{
    public void restart()
    {
        SceneManager.LoadScene("summer");
    }

    public void menü()
    {
        SceneManager.LoadScene("menü");
    }

}
