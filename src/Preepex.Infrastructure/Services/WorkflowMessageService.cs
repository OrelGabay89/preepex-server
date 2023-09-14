using Preepex.Core.Application;
using Preepex.Core.Application.Interfaces.Shared;
using Preepex.Core.Domain.Entities;
using Preepex.Core.Domain.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preepex.Infrastructure.Services
{
    public class WorkflowMessageService : IWorkflowMessageService
    {
        public Task<IList<int>> SendCustomerEmailRevalidationMessageAsync(Customer customer, int languageId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendCustomerEmailValidationMessageAsync(Customer customer, int languageId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendCustomerPasswordRecoveryMessageAsync(Customer customer, int languageId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendCustomerRegisteredNotificationMessageAsync(Customer customer, int languageId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendCustomerWelcomeMessageAsync(Customer customer, int languageId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendNewOrderNoteAddedCustomerNotificationAsync(OrderNote orderNote, int languageId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendNewReturnRequestCustomerNotificationAsync(ReturnRequest returnRequest, Orderitem orderItem, Order order)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendNewReturnRequestStoreOwnerNotificationAsync(ReturnRequest returnRequest, Orderitem orderItem, Order order, int languageId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendNewsLetterSubscriptionActivationMessageAsync(NewsLetterSubscription subscription, int languageId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendNewsLetterSubscriptionDeactivationMessageAsync(NewsLetterSubscription subscription, int languageId)
        {
            throw new NotImplementedException();
        }

        public Task<int> SendNotificationAsync(Messagetemplate messageTemplate, EmailAccount emailAccount, int languageId, IList<Token> tokens, string toEmailAddress, string toName, string attachmentFilePath = null, string attachmentFileName = null, string replyToEmailAddress = null, string replyToName = null, string fromEmail = null, string fromName = null, string subject = null)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendOrderCancelledCustomerNotificationAsync(Order order, int languageId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendOrderCompletedCustomerNotificationAsync(Order order, int languageId, string attachmentFilePath = null, string attachmentFileName = null)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendOrderPaidAffiliateNotificationAsync(Order order, int languageId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendOrderPaidCustomerNotificationAsync(Order order, int languageId, string attachmentFilePath = null, string attachmentFileName = null)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendOrderPaidStoreOwnerNotificationAsync(Order order, int languageId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendOrderPaidVendorNotificationAsync(Order order, Vendor vendor, int languageId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendOrderPlacedAffiliateNotificationAsync(Order order, int languageId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendOrderPlacedCustomerNotificationAsync(Order order, int languageId, string attachmentFilePath = null, string attachmentFileName = null)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendOrderPlacedStoreOwnerNotificationAsync(Order order, int languageId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendOrderPlacedVendorNotificationAsync(Order order, Vendor vendor, int languageId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendOrderRefundedCustomerNotificationAsync(Order order, decimal refundedAmount, int languageId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendOrderRefundedStoreOwnerNotificationAsync(Order order, decimal refundedAmount, int languageId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendProductEmailAFriendMessageAsync(Customer customer, int languageId, Product product, string customerEmail, string friendsEmail, string personalMessage)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendRecurringPaymentCancelledCustomerNotificationAsync(RecurringPayment recurringPayment, int languageId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendRecurringPaymentCancelledStoreOwnerNotificationAsync(RecurringPayment recurringPayment, int languageId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendRecurringPaymentFailedCustomerNotificationAsync(RecurringPayment recurringPayment, int languageId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendReturnRequestStatusChangedCustomerNotificationAsync(ReturnRequest returnRequest, Orderitem orderItem, Order order)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendShipmentDeliveredCustomerNotificationAsync(Shipment shipment, int languageId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendShipmentReadyForPickupNotificationAsync(Shipment shipment, int languageId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendShipmentSentCustomerNotificationAsync(Shipment shipment, int languageId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<int>> SendWishlistEmailAFriendMessageAsync(Customer customer, int languageId, string customerEmail, string friendsEmail, string personalMessage)
        {
            throw new NotImplementedException();
        }
    }
}
