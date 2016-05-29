using System;
using System.Collections.Generic;
using Kaznachey.KaznacheyPayment;

namespace TeamSpark.AzureDay.WebSite.CLI.Data
{
	internal static class KaznacheyTest
	{
		public static void Pay()
		{
			Console.WriteLine("Kaznachey pay");

			var kaznachey = new KaznacheyPaymentSystem(Guid.Parse("13FB1448-4DB5-4796-B0F8-79B92096E456"), "687B0BBA-CBEF-49D8-A0F6-BBA68446D848");
			foreach (var paySystem in kaznachey.GetMerchantInformation().PaySystems)
			{
				Console.WriteLine(paySystem.PaySystemName);
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
				ReturnUrl = "http://azureday.net/profile/my",
				StatusUrl = "http://azureday.net/profile/paymentconfirm"
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
