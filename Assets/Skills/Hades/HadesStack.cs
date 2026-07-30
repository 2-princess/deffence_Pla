using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HadesStack : MonoBehaviour
{
    public int stack = 0;
    public TMP_Text stackText;
    HashSet<GameObject> enermys = new HashSet<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enermy"))
        {
            enermys.Add(other.gameObject);
            Debug.Log("enermyPlus");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enermy"))
        {
            enermys.Remove(other.gameObject);
        }
    }

    public int StackPlus()
    {
        foreach (GameObject enermy in enermys)
        {
            stack++;
            stackText.text = stack.ToString();
        }
        return stack;
    }
}
