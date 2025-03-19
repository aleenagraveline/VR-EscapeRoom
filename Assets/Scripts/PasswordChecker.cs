using UnityEngine;
using TMPro;

public class PasswordChecker : MonoBehaviour
{
    private string password;
    private string answer;
    [SerializeField] private TextMeshProUGUI answerText;
    [SerializeField] private Countdown countdown;
    [SerializeField] private GameObject thirdDoor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        password = "05201123";
        answer = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(answer.Length == 0)
        {
            answerText.SetText("########");
        }
        else
        {
            answerText.SetText(answer);
        }

        if(answer.Length == password.Length)
        {
            if(answer.Equals(password))
            {
                thirdDoor.SetActive(false);
                Destroy(gameObject);
            }
            else
            {
                countdown.MultiplyTimer();
            }
        }
    }

    public void InsertNewNumber(string numPressed)
    {
        if(answer.Length != password.Length)
        {
            answer += numPressed;
        }
    }

    public void Backspace()
    {
        string newAnswer = "";

        for(int i=0; i<answer.Length-1; i++)
        {
            newAnswer += answer[i];
        }

        answer = newAnswer;
    }
}
