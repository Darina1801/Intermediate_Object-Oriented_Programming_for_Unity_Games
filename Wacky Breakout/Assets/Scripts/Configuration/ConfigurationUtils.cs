﻿using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
	#region Fields

	static ConfigurationData configurationData;

	#endregion

	#region Properties

	/// <summary>
	/// Gets the paddle move units per second
	/// </summary>
	/// <value>paddle move units per second</value>
	public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

	/// <summary>
	/// Gets ball impulse force
	/// </summary>
	/// <value>ball impulse force</value>>
	public static float BallImpulseForce
	{
	    get { return configurationData.BallImpulseForce; }
    }

    #endregion
    
    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
		configurationData = new ConfigurationData();
    }
}
