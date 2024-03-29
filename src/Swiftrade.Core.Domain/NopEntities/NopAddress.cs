﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Swiftrade.Core.Domain.Entities
{
    public partial class NopAddress
    {
        public NopAddress()
        {
            Affiliate = new HashSet<Affiliate>();
            CustomerBillingAddress = new HashSet<Customer>();
            CustomerShippingAddress = new HashSet<Customer>();
            OrderBillingAddress = new HashSet<Order>();
            OrderPickupAddress = new HashSet<Order>();
            OrderShippingAddress = new HashSet<Order>();
            Customer = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public int? CountryId { get; set; }
        public int? StateProvinceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipPostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string CustomAttributes { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        public virtual Country Country { get; set; }
        public virtual StateProvince StateProvince { get; set; }

        [NotMapped]
        public virtual ICollection<Affiliate> Affiliate { get; set; }

        [NotMapped]
        public virtual ICollection<Customer> CustomerBillingAddress { get; set; }

        [NotMapped]
        public virtual ICollection<Customer> CustomerShippingAddress { get; set; }

        [NotMapped]
        public virtual ICollection<Order> OrderBillingAddress { get; set; }

        [NotMapped]
        public virtual ICollection<Order> OrderPickupAddress { get; set; }

        [NotMapped]
        public virtual ICollection<Order> OrderShippingAddress { get; set; }

        [NotMapped]
        public virtual ICollection<Customer> Customer { get; set; }
    }
}