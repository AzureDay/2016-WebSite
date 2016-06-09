using System;
using System.Collections.Generic;
using Kaznachey.KaznacheyPayment;
using TeamSpark.AzureDay.WebSite.Config;

namespace TeamSpark.AzureDay.WebSite.CLI.Data
{
	internal static class KaznacheyTest
	{
		public static void Pay()
		{
			Console.WriteLine("Kaznachey pay");

			var kaznachey = new KaznacheyPaymentSystem(Configuration.LiqPayMerchantId, Configuration.LiqPayMerchantSecreet);
			foreach (var paySystem in kaznachey.GetMerchantInformation().PaySystems)
			{
				Console.WriteLine("{0} {1}",paySystem.Id, paySystem.PaySystemName);
			}

			var paySystemId = kaznachey.GetMerchantInformation().PaySystems[0].Id;

			var paymentRequest = new PaymentRequest(paySystemId);
			paymentRequest.Language = "RU";
			paymentRequest.Currency = "UAH";
			paymentRequest.PaymentDetail = new PaymentDetails
			{
				EMail = "boyko.ant@live.com",
				MerchantInternalUserId = "user id",
				MerchantInternalPaymentId = "ticker id",
				BuyerFirstname = "Anton",
				BuyerLastname = "Boyko",
				ReturnUrl = "http://azureday-2016-06-stage.azurewebsites.net/profile/my",
				StatusUrl = "http://azureday-2016-06-stage.azurewebsites.net/profile/paymentconfirm"
			};
			paymentRequest.Products = new List<Product>
			{
				new Product
				{
					ProductId = "ticket type",
					ProductItemsNum = 1,
					ProductName = "ticket type and user name",
					ProductPrice = 270
				}
			};

			var form = kaznachey.CreatePayment(paymentRequest).ExternalFormHtml;
			Console.WriteLine(form);
		}
	}
}
