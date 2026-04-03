using UnityEngine;
using UnityEngine.UI;

public class ScoreBar_script : MonoBehaviour
{
    [SerializeField] float current_score;
    [SerializeField] float max_score;
    [SerializeField] float[] star_scores = new float[3];
    [SerializeField] RectTransform[] stars = new RectTransform[3];

    private Slider slider;
    private float x_distance;

    void Start()
    {
        slider = GetComponent<Slider>();
        x_distance = GetComponent<RectTransform>().rect.width;
        for (int i = 0; i < star_scores.Length; i++)
        {
            float new_x = (star_scores[i] / max_score) * x_distance;
            stars[i].localPosition = new Vector3(new_x, 0, 0);
        }
    }

    void Update()
    {
        slider.value = current_score / max_score;
    }
}
