using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Timer : MonoBehaviour
{
    public float WaitSec;
    private int WaitSecInt;
    public TextMeshProUGUI Text;
    private void FixedUpdate()
    {
        if (WaitSec > 0)
        {
            WaitSec -= Time.fixedDeltaTime;
            WaitSecInt = (int)WaitSec;
            Text.text = WaitSecInt.ToString();
        }
        else {
            SceneManager.LoadScene(1);
        }
    }

}
