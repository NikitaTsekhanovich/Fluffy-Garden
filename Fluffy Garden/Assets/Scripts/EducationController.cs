using UnityEngine;

public class EducationController : MonoBehaviour
{
    [SerializeField] private GameObject _educationBlock;

    private void OnEnable()
    {
        Time.timeScale = 0f;
        _educationBlock.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            EndEducation();
    }

    private void EndEducation()
    {
        Time.timeScale = 1f;
        _educationBlock.SetActive(false);
        gameObject.SetActive(false);
    }
}
