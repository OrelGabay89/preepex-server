﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Preepex.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Preepex.Core.Domain.Entities
{
    public partial class Customer : BaseEntity<int>
    {
        public Customer()
        {
            Activitylog = new HashSet<Activitylog>();
            BackinStockSubScription = new HashSet<Backinstocksubscription>();
            BlogComment = new HashSet<BlogComment>();
            CustomerPassword = new HashSet<Customerpassword>();
            ExternalAuthenticationRecord = new HashSet<Externalauthenticationrecord>();
            ForumsPost = new HashSet<ForumsPost>();
            ForumsPrivateMessageFromCustomer = new HashSet<ForumsPrivatemessage>();
            ForumsPrivateMessageToCustomer = new HashSet<ForumsPrivatemessage>();
            ForumsSubscription = new HashSet<ForumsSubscription>();
            ForumsTopic = new HashSet<ForumsTopic>();
            Log = new HashSet<Log>();
            NewsComment = new HashSet<NewsComment>();
            Order = new HashSet<Order>();
            PollvotingRecord = new HashSet<Pollvotingrecord>();
            ProductReview = new HashSet<Productreview>();
            ReturnRequest = new HashSet<ReturnRequest>();
            RewardPointsHistory = new HashSet<Rewardpointshistory>();
            ShoppingCartItem = new HashSet<Shoppingcartitem>();
            Address = new HashSet<NopAddress>();
            CustomerRole = new HashSet<Customerrole>();
        }
        public string Username { get; set; }
        public string Email { get; set; }
        public string EmailToRevalidate { get; set; }
        public string SystemName { get; set; }
        public int? BillingAddressId { get; set; }
        public int? ShippingAddressId { get; set; }
        public Guid CustomerGuid { get; set; }
        public string AdminComment { get; set; }
        public bool IsTaxExempt { get; set; }
        public int AffiliateId { get; set; }
        public int VendorId { get; set; }
        public bool HasShoppingCartItems { get; set; }
        public bool RequireReLogin { get; set; }
        public int FailedLoginAttempts { get; set; }
        public DateTime? CannotLoginUntilDateUtc { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public bool IsSystemAccount { get; set; }
        public string LastIpAddress { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? LastLoginDateUtc { get; set; }
        public DateTime LastActivityDateUtc { get; set; }
        public int RegisteredInStoreId { get; set; }

        [NotMapped]
        public virtual NopAddress BillingAddress { get; set; }

        [NotMapped]
        public virtual NopAddress ShippingAddress { get; set; }
        public virtual ICollection<Activitylog> Activitylog { get; set; }
        public virtual ICollection<Backinstocksubscription> BackinStockSubScription { get; set; }
        public virtual ICollection<BlogComment> BlogComment { get; set; }
        public virtual ICollection<Customerpassword> CustomerPassword { get; set; }
        public virtual ICollection<Externalauthenticationrecord> ExternalAuthenticationRecord { get; set; }
        public virtual ICollection<ForumsPost> ForumsPost { get; set; }

        [NotMapped]
        public virtual ICollection<ForumsPrivatemessage> ForumsPrivateMessageFromCustomer { get; set; }

        [NotMapped]
        public virtual ICollection<ForumsPrivatemessage> ForumsPrivateMessageToCustomer { get; set; }
        public virtual ICollection<ForumsSubscription> ForumsSubscription { get; set; }
        public virtual ICollection<ForumsTopic> ForumsTopic { get; set; }
        public virtual ICollection<Log> Log { get; set; }
        public virtual ICollection<NewsComment> NewsComment { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Pollvotingrecord> PollvotingRecord { get; set; }
        public virtual ICollection<Productreview> ProductReview { get; set; }
        public virtual ICollection<ReturnRequest> ReturnRequest { get; set; }
        public virtual ICollection<Rewardpointshistory> RewardPointsHistory { get; set; }
        public virtual ICollection<Shoppingcartitem> ShoppingCartItem { get; set; }
        
        [NotMapped]
        public virtual ICollection<NopAddress> Address { get; set; }
        public virtual ICollection<Customerrole> CustomerRole { get; set; }
    }
}