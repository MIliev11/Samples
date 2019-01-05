﻿using System;

using Xamarin.Forms;

namespace StoreCredentials
{
	public class LoginPageCS : ContentPage
	{
		ICredentialsService storeService;
		Entry usernameEntry;
		Entry passwordEntry;
		Label messageLabel;

		public LoginPageCS ()
		{
			storeService = DependencyService.Get<ICredentialsService> ();

			usernameEntry = new Entry {
				Placeholder = "username"
			};
			passwordEntry = new Entry {
				IsPassword = true
			};
			messageLabel = new Label ();
			var loginButton = new Button {
				Text = "Login"
			};
			loginButton.Clicked += OnLoginButtonClicked;

			Title = "Login Page";
			Content = new StackLayout { 
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = {
					new Label { Text = "Username" },
					usernameEntry,
					new Label { Text = "Password" },
					passwordEntry,
					loginButton,
					messageLabel
				}
			};
		}

		async void OnLoginButtonClicked (object sender, EventArgs e)
		{
			string userName = usernameEntry.Text;
			string password = passwordEntry.Text;

			var isValid = AreCredentialsCorrect (userName, password);
			if (isValid) {
				bool doCredentialsExist = storeService.DoCredentialsExist ();
				if (!doCredentialsExist) {
					storeService.SaveCredentials (userName, password);
				}

				Navigation.InsertPageBefore (new HomePage (), this);
				await Navigation.PopAsync ();
			} else {
				messageLabel.Text = "Login failed";
				passwordEntry.Text = string.Empty;
			}
		}

		bool AreCredentialsCorrect (string username, string password)
		{
			return username == Constants.Username && password == Constants.Password;
		}
	}
}
