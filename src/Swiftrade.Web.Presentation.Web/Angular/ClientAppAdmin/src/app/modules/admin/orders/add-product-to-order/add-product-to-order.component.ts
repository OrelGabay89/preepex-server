import { AfterViewInit, Component, OnInit, QueryList, ViewChild, ViewChildren, ViewEncapsulation } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add-product-to-order',
  templateUrl: './add-product-to-order.component.html',
  encapsulation: ViewEncapsulation.None
})
export class AddProductToOrderComponent implements OnInit, AfterViewInit {
  @ViewChildren(MatPaginator) paginator = new QueryList<MatPaginator>();
  @ViewChild(MatSort) sort: MatSort;

  orderId: string;
  isLoading: boolean;

  public orders = [
    {
      name: 'Build your own computer',
      sku: 'COMP_CUST'
    },
    {
      name: 'Digital Storm VANQUISH 3 Custom Performance PC',
      sku: 'DS_VA3_PC'
    },
    {
      name: 'Lenovo IdeaCentre 600 All-in-One PC',
      sku: 'LE_IC_600'
    },
    {
      name: 'Apple MacBook Pro 13-inch',
      sku: 'AP_MBP_13'
    },
    {
      name: 'HP Spectre XT Pro UltraBook',
      sku: 'COMP_CUST'
    },
    {
      name: 'HP Envy 6-1180ca 15.6-Inch Sleekbook',
      sku: 'AP_MBP_13'
    },
    {
      name: 'Lenovo Thinkpad X1 Carbon Laptop',
      sku: 'AD_CS4_PH'
    },
    {
      name: 'Windows 8 Pro',
      sku: 'LE_TX1_CL'
    },
  ];

  public filterValue = {
    name: '',
    category: 'all',
    manufacturer: 'all',
    type: 'all',
  };

  public ordersDisplayedColumns: string[] = ['select', 'name', 'sku'];
  public ordersDataSource = new MatTableDataSource<any>(this.orders);

  constructor(private _route: ActivatedRoute,
    private _router: Router,) {
    const snapshot = this._route.snapshot;
    this.orderId = snapshot.params.id;
  }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    this.ordersDataSource.paginator = this.paginator.toArray()[0];
    this.ordersDataSource.sort = this.sort;
  }

  public back(): void {
    this._router.navigate(['orders/edit', this.orderId]);
  }

  public filterData(): void {

  }

  public clearSearchFilter(): void {

  }

}
