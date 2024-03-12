import { ChangeDetectionStrategy, Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-footer-items',
  templateUrl: './footer-items.component.html',
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class FooterItemsComponent implements OnInit {
  public footerItemsForm: FormGroup;
  public footerItems = [
    {
      label: 'Sitemap',
      id: 'sitemap'
    },
    {
      label: 'Shipping & Returns',
      id: 'shippingReturns'
    },
    {
      label: 'Privacy notice',
      id: 'privacyNotice'
    },
    {
      label: 'Conditions of use',
      id: 'conditionsUse'
    },
    {
      label: 'About us',
      id: 'aboutUs'
    },
    {
      label: 'Contact us',
      id: 'contactUs'
    },
    {
      label: 'Search',
      id: 'search'
    },
    {
      label: 'News',
      id: 'news'
    },
    {
      label: 'Blog',
      id: 'blog'
    },
    {
      label: 'Recently viewed products',
      id: 'recentProducts'
    },
    {
      label: 'Compare products list',
      id: 'compareList'
    },
    {
      label: 'New products',
      id: 'newProducts'
    },
    {
      label: 'My account',
      id: 'myAccount'
    },
    {
      label: 'Orders',
      id: 'orders'
    },
    {
      label: 'Addresses',
      id: 'addresses'
    },
    {
      label: 'Shopping basket',
      id: 'shoppingBasket'
    },
    {
      label: 'Wishlist',
      id: 'wishlist'
    },
    {
      label: 'Apply for vendor account',
      id: 'applyVendorAccount'
    }
  ];

  constructor(
    private _formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this.footerItemsForm = this._formBuilder.group({
      sitemap: [true],
      shippingReturns: [true],
      privacyNotice: [true],
      conditionsUse: [false],
      aboutUs: [false],
      contactUs: [false],
      search: [true],
      news: [true],
      blog: [true],
      recentProducts: [false],
      compareList: [false],
      newProducts: [false],
      myAccount: [true],
      orders: [true],
      addresses: [true],
      shoppingBasket: [true],
      wishlist: [true],
      applyVendorAccount: [true]
    });
  }

}
