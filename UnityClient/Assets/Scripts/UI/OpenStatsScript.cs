using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenStatsScript : MonoBehaviour
{
    public Button TargetButton;
    public GameObject TargetStatsCard;

    private bool _open = false;

    // Start is called before the first frame update
    void Start()
    {
        var button = TargetButton.GetComponent<Button>();
        button.onClick.AddListener(() => 
        {
            _open = !_open;
        });
    }

    // Update is called once per frame
    void Update()
    {
        var position = TargetStatsCard.transform.position;

        if (_open && position.x < -4)
        {
            TargetStatsCard.transform.position = new Vector2(
                position.x + 0.2f,
                position.y);
        }

        if (!_open && position.x > -14)
        {
            TargetStatsCard.transform.position = new Vector2(
               position.x - 0.2f,
               position.y);
        }
    }
}
