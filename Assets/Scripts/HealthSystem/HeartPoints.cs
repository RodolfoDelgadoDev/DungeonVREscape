using UnityEngine;
using System;

public class HeartPoints : MonoBehaviour
{
    [SerializeField] private GameObject _heartsGrid;
    [SerializeField] private GameObject _heart;

    // Start is called before the first frame update
    void Start()
    {
        HeartInstantiateAtStart();
    }

    // Instantiate hearts at start, -1 is because of the first in the scene
    private void HeartInstantiateAtStart()
    {
        for (int i = 0; i < HealthManager.healthManager.playerHealth.MaxHealth - 1; i++)
        {
            Instantiate(_heart, _heartsGrid.transform);
        }
    }

    void Update()
    {
        HeartsHandler();
    }

    /// <summary>
    /// Handle the hearts on screen, remove and add
    /// </summary>
    public void HeartsHandler()
    {
        for (int i = 0; i < HealthManager.healthManager.playerHealth.MaxHealth; i++)
        {
            // Set active heart until current health
            if (i < HealthManager.healthManager.playerHealth.CurrentHealth)
            {
                _heartsGrid.transform.GetChild(i).gameObject.SetActive(true);
            }
            // Set unactive heart from current health to max health
            else if (i < HealthManager.healthManager.playerHealth.MaxHealth)
            {
                _heartsGrid.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
