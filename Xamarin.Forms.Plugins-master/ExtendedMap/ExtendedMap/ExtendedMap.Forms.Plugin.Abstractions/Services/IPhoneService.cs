﻿using ExtendedMap.Forms.Plugin.Abstractions.Models;

namespace ExtendedMap.Forms.Plugin.Abstractions.Services
{
	public interface IPhoneService
	{
		void OpenBrowser (string url);

	    /// <summary>
	    /// Opens native dialog to dial the specified number.
	    /// </summary>
	    /// <param name="number">Number to dial.</param>
	    /// <param name="name"></param>
	    void DialNumber (string number, string name);

		void ShareText (string text);

		void LaunchNavigationAsync (NavigationModel navigationModel);
	}
}

