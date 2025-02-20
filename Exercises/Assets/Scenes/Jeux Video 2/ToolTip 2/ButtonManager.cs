using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void ShowName(GameObject animalObject)
    {
        IShowName showName = animalObject.GetComponent<IShowName>();
        if (showName != null)
        {
            _text.text = showName.GetName();
        }
        else
        {
            _text.text = "Unknown Animal";
        }
    }

    public void Worker(GameObject animalObject)
    {
        IWorker worker = animalObject.GetComponent<IWorker>();
        if (worker != null)
        {
            worker.Work();
        }
        else
        {
            Debug.Log($"{animalObject.name} doesn't work.");
        }
    }
}
