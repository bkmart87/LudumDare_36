// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;
using System.Collections;

public class LookingAtStuff : MonoBehaviour, IGvrGazeResponder 
{
	private string dostuff = "";
	public float highlightFactor = 1.0f;
	private Color startColor;
	private Color highlight;
	public static bool Showprints, getTeleported; 

	void Awake() 
	{
		startColor = GetComponent<Renderer>().material.color;
		highlight = (startColor * (highlightFactor));
		SetGazedAt(false);
		dostuff = gameObject.tag;

	}

	void LateUpdate() 
	{
		GvrViewer.Instance.UpdateState();
		if (GvrViewer.Instance.BackButtonPressed) 
		{
			Application.Quit();
		}
	}

	public void SetGazedAt(bool gazedAt) 
	{
		GetComponent<Renderer>().material.color = gazedAt ? highlight : startColor;
	}

	public void ToggleVRMode() 
	{
		GvrViewer.Instance.VRModeEnabled = !GvrViewer.Instance.VRModeEnabled;
	}

	public void ToggleDistortionCorrection() 
	{
		switch(GvrViewer.Instance.DistortionCorrection)
		{
		case GvrViewer.DistortionCorrectionMethod.Unity:
			GvrViewer.Instance.DistortionCorrection = GvrViewer.DistortionCorrectionMethod.Native;
			break;

		case GvrViewer.DistortionCorrectionMethod.Native:
			GvrViewer.Instance.DistortionCorrection = GvrViewer.DistortionCorrectionMethod.None;
			break;

		case GvrViewer.DistortionCorrectionMethod.None:

		default:
			GvrViewer.Instance.DistortionCorrection = GvrViewer.DistortionCorrectionMethod.Unity;
			break;
		}
	}

	public void ToggleDirectRender() 
	{
		GvrViewer.Controller.directRender = !GvrViewer.Controller.directRender;
	}

	public void DoShit(string whatToDo) 
	{
		//make this more like pick up or delete depending on a string

		if (whatToDo == "NavMesh")
		{
			getTeleported = true; 
		}

		if(whatToDo == "TurnOn")
		{
			//do moving stuff
		}
		if(whatToDo == "TurnOff")
		{
			//do moving stuff
		}
	}

	#region IGvrGazeResponder implementation

	/// Called when the user is looking on a GameObject with this script,
	/// as long as it is set to an appropriate layer (see GvrGaze).
	public void OnGazeEnter()
	{
		SetGazedAt(true);
		if(dostuff == "NavMesh")
		{
			Showprints = true;
		}

	}

	/// Called when the user stops looking on the GameObject, after OnGazeEnter
	/// was already called.
	public void OnGazeExit() 
	{
		SetGazedAt(false);
		if(dostuff == "NavMesh")
		{
			Showprints = false;
		}

	}

	/// Called when the viewer's trigger is used, between OnGazeEnter and OnGazeExit.
	public void OnGazeTrigger()
	{
		DoShit(dostuff);
	}

	#endregion
}
