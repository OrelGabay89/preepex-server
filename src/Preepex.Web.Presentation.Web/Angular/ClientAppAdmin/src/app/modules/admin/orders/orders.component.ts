import { AfterViewInit, Component, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html'
})
export class OrdersComponent implements OnInit, AfterViewInit {
  @ViewChildren(MatPaginator) paginator = new QueryList<MatPaginator>();
  @ViewChild(MatSort) sort: MatSort;

  public orders = [
    {
      orderNumber: 1,
      orderStatus: 'completed',
      paymentStatus: 'paid',
      shippingStatus: 'delivered',
      billingEmailAddress: 'victoria_victoria@nopCommerce.com',
      createdOn: '01/12/2022 4:32:09 PM',
      orderTotal: 43.50,
      isSelected: false
    },
    {
      orderNumber: 2,
      orderStatus: 'processing',
      paymentStatus: 'paid',
      shippingStatus: 'notYetShipped',
      billingEmailAddress: 'steve_gates@nopCommerce.com',
      createdOn: '01/12/2022 4:32:08 PM',
      orderTotal: 1855.00,
      isSelected: false
    },
    {
      orderNumber: 3,
      orderStatus: 'pending',
      paymentStatus: 'pending',
      shippingStatus: 'notYetShipped',
      billingEmailAddress: 'arthur_holmes@nopCommerce.com',
      createdOn: '01/12/2022 4:32:08 PM',
      orderTotal: 2460.50,
      isSelected: false
    },
    {
      orderNumber: 4,
      orderStatus: 'pending',
      paymentStatus: 'pending',
      shippingStatus: 'shippingNotRequired',
      billingEmailAddress: 'james_pan@nopCommerce.com',
      createdOn: '01/12/2022 4:32:08 PM',
      orderTotal: 8.80,
      isSelected: false
    },
    {
      orderNumber: 5,
      orderStatus: 'processing',
      paymentStatus: 'paid',
      shippingStatus: 'shipped',
      billingEmailAddress: 'brenda_lindgren@nopCommerce.com',
      createdOn: '01/12/2022 4:32:08 PM',
      orderTotal: 102.00,
      isSelected: false
    }
  ];

  public filterValue = {
    startDate: null,
    endDate: null,
    warehouse: 'all',
    product: '',
    orderStatuses: [],
    paymentStatuses: [],
    shippingStatuses: [],
    vendor: 'all',
    billingPhoneNumber: '',
    billingEmailAddress: '',
    billingLastName: '',
    billingCountry: 'all',
    orderNotes: '',
    orderNumber: undefined
  };

  public isLoading: boolean = false;

  public filteredOrders = this.orders;
  public ordersDisplayedColumns: string[] = ['select', 'orderNumber', 'orderStatus', 'paymentStatus', 'shippingStatus', 'billingEmailAddress', 'createdOn', 'orderTotal', 'action'];
  public isAllSelected: boolean;
  public ordersDataSource = new MatTableDataSource<any>(this.filteredOrders); //todo: change type


  constructor( private _router: Router,
    private _route: ActivatedRoute,) { }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    this.ordersDataSource.paginator = this.paginator.toArray()[0];
    this.ordersDataSource.sort = this.sort;
  }

  filterData(): void {

  }

  clearSearchFilter(): void {

  }

  masterToggle(event): void {
    if (event.checked) {
      this.orders.forEach(x => x.isSelected = true);
    } else {
      this.orders.forEach(x => x.isSelected = false);
    }
  }

  toggleSelect(event, element): void {
    const foundItem = this.orders.find(cat => cat.orderNumber === element.orderNumber);
    foundItem.isSelected = event.checked;
    this.isAllSelected = this.orders.every(cat => cat.isSelected);
  }

  editOrder(orderNumber: number): void {
    this._router.navigate(['edit', orderNumber], { relativeTo: this._route });
  }

}
