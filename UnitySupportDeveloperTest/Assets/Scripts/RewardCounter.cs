using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Counter for the number of rewards the player has won.
/// </summary>
public class RewardCounter : MonoBehaviour
{
    // The text object for displaying the reward counter
    private TextMeshProUGUI _rewardCounterText;

    // The current number of rewards the player has won
    private int _numRewards = 0;

    void Start()
    {
        // Assign the reward counter text object
        _rewardCounterText = GetComponent<TextMeshProUGUI>();

        // Set the reward text to display the current number of rewards
        SetRewardText();
    }

    /// <summary>
    /// Display the current number of rewards using the reward counter text.
    /// </summary>
    private void SetRewardText()
    {
        _rewardCounterText.text = "Number of Rewards: " + _numRewards;
    }

    /// <summary>
    /// Increase the number of rewards by 1 and display it.
    /// </summary>
    public void AddReward()
    {
        _numRewards++;
        SetRewardText();
    }
}
