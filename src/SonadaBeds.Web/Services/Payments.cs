namespace SonadaBeds.Web.Services;
public record PaymentRequest(string OrderNumber,decimal Amount,string Currency,string Email,string ReturnUrl);
public record PaymentResult(bool Succeeded,string? RedirectUrl,string? ProviderReference,string? Error);
public interface IPaymentProvider{Task<PaymentResult> CreatePaymentAsync(PaymentRequest request,CancellationToken cancellationToken=default);Task<bool> HandleWebhookAsync(string payload,string signature,CancellationToken cancellationToken=default);}
public sealed class ManualPaymentProvider:IPaymentProvider{public Task<PaymentResult>CreatePaymentAsync(PaymentRequest request,CancellationToken cancellationToken=default)=>Task.FromResult(new PaymentResult(true,request.ReturnUrl,"MANUAL-"+request.OrderNumber,null));public Task<bool>HandleWebhookAsync(string payload,string signature,CancellationToken cancellationToken=default)=>Task.FromResult(false);}
