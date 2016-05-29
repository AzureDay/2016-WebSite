namespace Kaznachey.KaznacheyPayment
{
    /// <summary>
    /// Represent responce from CreatePayment operation
    /// </summary>
    public class CreatePaymentResponse: BaseResponse
    {
		public string ExternalForm { get; set; }

	    private string _externalFormHtml;

		public string ExternalFormHtml
		{
			get
			{
				if (string.IsNullOrEmpty(_externalFormHtml))
				{
					_externalFormHtml = Base64Decode(ExternalForm);
				}
				return _externalFormHtml;
			}
		}

		private static string Base64Decode(string base64EncodedData)
		{
			var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
			return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
		}
	}
}
