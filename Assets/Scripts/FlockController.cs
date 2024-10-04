using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlockController : MonoBehaviour
{
    public Flock whiteFlock;
    public Flock blueFlock;
    public Flock greenFlock;

    public Slider whiteStartingCountSlider;
    public Slider whiteDriveFactorSlider;
    public TextMeshProUGUI whiteStartingCountText;
    public TextMeshProUGUI whiteDriveFactorText;

    public Slider blueStartingCountSlider;
    public Slider blueDriveFactorSlider;
    public TextMeshProUGUI blueStartingCountText;
    public TextMeshProUGUI blueDriveFactorText;

    public Slider greenStartingCountSlider;
    public Slider greenDriveFactorSlider;
    public TextMeshProUGUI greenStartingCountText;
    public TextMeshProUGUI greenDriveFactorText;

    public void SetWhiteFlockValues()
    {
        whiteFlock.startingCount = (int)whiteStartingCountSlider.value;
        whiteFlock.driveFactor = (int)whiteDriveFactorSlider.value;
        whiteStartingCountText.text = "Flock Count: " + whiteStartingCountSlider.value.ToString();
        whiteDriveFactorText.text = "Speed: " + whiteDriveFactorSlider.value.ToString();
    }

    public void SetBlueFlockValues()
    {
        blueFlock.startingCount = (int)blueStartingCountSlider.value;
        blueFlock.driveFactor = (int)blueDriveFactorSlider.value;
        blueStartingCountText.text = "Flock Count: " + blueStartingCountSlider.value.ToString();
        blueDriveFactorText.text = "Speed: " + blueDriveFactorSlider.value.ToString();
    }

    public void SetGreenFlockValues()
    {
        greenFlock.startingCount = (int)greenStartingCountSlider.value;
        greenFlock.driveFactor = (int)greenDriveFactorSlider.value;
        greenStartingCountText.text = "Flock Count: " + greenStartingCountSlider.value.ToString();
        greenDriveFactorText.text = "Speed: " + greenDriveFactorSlider.value.ToString();
    }

    void Start()
    {
        whiteStartingCountSlider.value = whiteFlock.startingCount;
        whiteDriveFactorSlider.value = whiteFlock.driveFactor;
        
        blueStartingCountSlider.value = blueFlock.startingCount;
        blueDriveFactorSlider.value = blueFlock.driveFactor;
        
        greenStartingCountSlider.value = greenFlock.startingCount;
        greenDriveFactorSlider.value = greenFlock.driveFactor;
        
        whiteStartingCountSlider.onValueChanged.AddListener(delegate { SetWhiteFlockValues(); });
        whiteDriveFactorSlider.onValueChanged.AddListener(delegate { SetWhiteFlockValues(); });
        
        blueStartingCountSlider.onValueChanged.AddListener(delegate { SetBlueFlockValues(); });
        blueDriveFactorSlider.onValueChanged.AddListener(delegate { SetBlueFlockValues(); });
        
        greenStartingCountSlider.onValueChanged.AddListener(delegate { SetGreenFlockValues(); });
        greenDriveFactorSlider.onValueChanged.AddListener(delegate { SetGreenFlockValues(); });

        whiteStartingCountSlider.onValueChanged.AddListener(delegate { AddWhiteAgents((int)whiteStartingCountSlider.value); });
        blueStartingCountSlider.onValueChanged.AddListener(delegate { AddBlueAgents((int)blueStartingCountSlider.value); });
        greenStartingCountSlider.onValueChanged.AddListener(delegate { AddGreenAgents((int)greenStartingCountSlider.value); });
    }

    void Update()
    {
        SetBlueFlockValues();
        SetGreenFlockValues();
        SetWhiteFlockValues();
    }

    public void AddWhiteAgents(int count)
    {
        whiteFlock.AddAgents(count);
    }

    public void AddBlueAgents(int count)
    {
        blueFlock.AddAgents(count);
    }

    public void AddGreenAgents(int count)
    {
        greenFlock.AddAgents(count);
    }
}
