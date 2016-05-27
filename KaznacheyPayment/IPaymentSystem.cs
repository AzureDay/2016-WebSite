namespace Kaznachey.KaznacheyPayment
{

    public interface IPaymentSystem
    {
        MerchantInfoResponse GetMerchantInformation();

        CreatePaymentResponse CreatePayment(PaymentRequest payment);


        bool ValidateResponse(PaymentResponse resp);
    }
}
