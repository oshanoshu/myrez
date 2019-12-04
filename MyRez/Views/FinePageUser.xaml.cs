using System;
using System.Collections.Generic;
using JudoDotNetXamarin;
using JudoPayDotNet.Enums;
using JudoPayDotNet.Models;
using MyRez.ViewModels;
using Xamarin.Forms;

namespace MyRez.Views
{
    public partial class FinePageUser : ContentPage
    {
        public FinePageUser()
        {
            InitializeComponent();
            BindingContext = new FineUserViewModel();
        }
        public void OnButtonClicked(Object sender, EventArgs e)
        {
            var judo = new Judo()
            {
                JudoId = "100583-590",
                Token = "hZGImISgKx0YYNeC",
                Secret = "6dbc37c9a11acd021594fbdc8d3518a145ebe67af16a8ae0011f1522187c3b50",
                Environment = JudoEnvironment.Sandbox,
                Amount = 0.01m,
                Currency = "GBP",
                ConsumerReference = "YourUniqueReference"
            };

            var theme = new Theme
            {
                ButtonBackgroundColor = Color.Maroon,
                EntryTextColor = Color.Black
            };
            judo.Theme = theme;

            var paymentPage = new PaymentPage(judo);
            paymentPage.ResultHandler += PaymentResultHandler;
            Navigation.PushAsync(paymentPage);


        }
        internal async void PaymentResultHandler(object sender, IResult<ITransactionResult> result)
        {
            await Navigation.PopAsync();
            if (result.HasError)
            {
                await DisplayAlert("Payment error", "Code: " + result.Error.Code, "OK");
            }
            else if ("Success".Equals(result.Response.Result))
            {
                await DisplayAlert("Payment successful", "Receipt ID: " + result.Response.ReceiptId, "OK");
               
            }
            else if ("Declined".Equals(result.Response.Result))
            {
                await DisplayAlert("Payment declined", "Receipt ID: " + result.Response.ReceiptId, "OK");
            }
        }

    }
}
