import { AfterViewInit, Component, QueryList, ViewChild, ViewChildren, ViewEncapsulation } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexTitleSubtitle,
  ApexAnnotations
} from 'ng-apexcharts';

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  title: ApexTitleSubtitle;
  annotation: ApexAnnotations;
};
export type OrderTotalOptions = {
  status: string;
  today: number;
  week: number;
  month: number;
  year: number;
  alltime: number;
};
export type LatestOrderTotalOptions = {
  order: number;
  orderNumber: number;
  status: string;
  customer: string;
  email: string;
  createdOn: Date;
  view: string;
};
export type PopularKeywordOptions = {
  keyword: string;
  count: number;
};
export type BestCategoriesOptions = {
  category: string;
  order: number;
  sales: number;
};
export type BestSellerCategoriesOptions = {
  name: string;
  totalQuantity: number;
  totalAmount: number;
  view: string;
};
export type BestSellerBrandOptions = {
  name: string;
  id: string;
  totalQuantity: number;
  totalAmount: number;
  view: string;
};

@Component({
  selector: 'dashboard',
  templateUrl: './dashboard.component.html',
  encapsulation: ViewEncapsulation.None
})
export class DashboardComponent implements AfterViewInit {

  @ViewChild('chart') chart: ChartComponent;
  @ViewChildren(MatPaginator) paginator = new QueryList<MatPaginator>();

  public summaryCards = [
    {
      label: 'Total Orders',
      numberClass: 'text-blue-500',
      labelClass: 'text-blue-600 dark:text-blue-500',
      totalTask: 38,
      navLink: '/orders'
    },
    {
      label: 'Average Basket',
      numberClass: 'text-red-500',
      labelClass: 'text-red-600 dark:text-red-500',
      totalTask: 12,
      navLink: '/dashboard'
    },
    {
      label: 'Number of Active Products',
      numberClass: 'text-amber-500',
      labelClass: 'text-amber-600 dark:text-amber-500',
      totalTask: 24,
      navLink: '/products'
    },
    {
      label: 'Registered Customers',
      numberClass: 'text-green-500',
      labelClass: 'text-green-600 dark:text-green-500',
      totalTask: 15,
      navLink: '/dashboard'
    }
  ];

  public orderTotals: OrderTotalOptions[] = [
    { status: 'Pending', today: 1, week: 2, month: 0, year: 75, alltime: 8686 },
    { status: 'Processing', today: 2, week: 5, month: 5, year: 45, alltime: 5445 },
    { status: 'Complete', today: 3, week: 4, month: 45, year: 56, alltime: 1212 },
    { status: 'Cancelled', today: 4, week: 1, month: 25, year: 32, alltime: 1212 }
  ];
  public orderColumns = [
    {
      label: 'Order Status', name: 'status'
    }, {
      label: 'Today', name: 'today'
    }, {
      label: 'This Week', name: 'week'
    }, {
      label: 'This Month', name: 'month'
    }, {
      label: 'This Year', name: 'year'
    }, {
      label: 'All time', name: 'alltime'
    }];
  public orderDisplayedColumns: string[];

  public latestOrderTotals: LatestOrderTotalOptions[] = [
    { order: 2, orderNumber: 1, status: 'Pending', customer: 'Victoria Terces', email: 'victoria@nopCommerce.com', createdOn: new Date(), view: '' },
    { order: 5, orderNumber: 2, status: 'Processing', customer: 'Steve Gates', email: 'steve@nopCommerce.com', createdOn: new Date(), view: '' },
    { order: 0, orderNumber: 3, status: 'Pending', customer: 'Arthur Holmes', email: 'arthur@nopCommerce.com', createdOn: new Date(), view: '' },
    { order: 9, orderNumber: 4, status: 'Complete', customer: 'James Pan', email: 'james@nopCommerce.com', createdOn: new Date(), view: '' },
    { order: 2, orderNumber: 5, status: 'Pending', customer: 'Victoria Terces', email: 'victoria@nopCommerce.com', createdOn: new Date(), view: '' },
    { order: 9, orderNumber: 6, status: 'Complete', customer: 'James Pan', email: 'james@nopCommerce.com', createdOn: new Date(), view: '' },
    { order: 2, orderNumber: 7, status: 'Complete', customer: 'Brenda Lindgren', email: 'Brenda@nopCommerce.com', createdOn: new Date(), view: '' }
  ];

  public popularKeyword: PopularKeywordOptions[] = [
    { keyword: 'computer', count: 15 },
    { keyword: 'camera', count: 36 },
    { keyword: 'jewelry', count: 24 },
    { keyword: 'shoes', count: 12 },
    { keyword: 'jeans', count: 8 },
    { keyword: 'tshirt', count: 42 },
    { keyword: 'cap', count: 38 },
    { keyword: 'socks', count: 17 },
    { keyword: 'mobile', count: 11 },
    { keyword: 'gift', count: 28 }
  ];
  public bestCategories: BestCategoriesOptions[] = [
    { category: 'jeans', order: 8, sales: 2500 },
    { category: 'tshirt', order: 42, sales: 1200 },
    { category: 'cap', order: 38, sales: 5250 },
    { category: 'socks', order: 17, sales: 1700 },
    { category: 'mobile', order: 11, sales: 1250 },
    { category: 'gift', order: 28, sales: 2428 },
    { category: 'computer', order: 15, sales: 1520 },
    { category: 'camera', order: 36, sales: 3650 },
    { category: 'jewelry', order: 24, sales: 4120 },
    { category: 'shoes', order: 12, sales: 800 }
  ];
  public bestSellerCategories: BestSellerCategoriesOptions[] = [
    { name: 'Night Visions', totalQuantity: 1, totalAmount: 28, view: '' },
    { name: 'Apple iCam', totalQuantity: 7, totalAmount: 12.5, view: '' },
    { name: 'Science & Faith', totalQuantity: 2, totalAmount: 36, view: '' },
    { name: 'Leica T Mirrorless Digital Camera', totalQuantity: 9, totalAmount: 1700, view: '' },
    { name: 'Pride and Prejudice', totalQuantity: 1, totalAmount: 1250, view: '' },
    { name: 'Flower Girl Bracelet', totalQuantity: 2, totalAmount: 56, view: '' },
    { name: 'If You Wait (donation)', totalQuantity: 3, totalAmount: 78, view: '' },
    { name: 'First Prize Pies', totalQuantity: 2, totalAmount: 45, view: '' },
    { name: 'Engagement Ring', totalQuantity: 4, totalAmount: 874, view: '' }
  ];
  public bestSellerBrand: BestSellerBrandOptions[] = [
    { name: 'Apple', id: '1', totalQuantity: 1, totalAmount: 1250, view: '' },
    { name: 'Lenovo', id: '2', totalQuantity: 2, totalAmount: 56, view: '' },
    { name: 'Nike', id: '3', totalQuantity: 3, totalAmount: 78, view: '' },
    { name: 'Dell', id: '4', totalQuantity: 2, totalAmount: 45, view: '' },
    { name: 'HP', id: '5', totalQuantity: 1, totalAmount: 28, view: '' },
    { name: 'Puma', id: '6', totalQuantity: 7, totalAmount: 12.5, view: '' },
    { name: 'Sketchers', id: '7', totalQuantity: 2, totalAmount: 36, view: '' }
  ];

  public popularKeywordDisplayedColumns: string[] = ['keyword', 'count'];
  public bestCategoriesDisplayedColumns: string[] = ['category', 'order', 'sales'];
  public latestOrderDisplayedColumns: string[] = ['order', 'status', 'customer', 'createdOn', 'view'];
  public bestSellerCategoriesDisplayedColumns: string[] = ['name', 'totalQuantity', 'totalAmount', 'view'];
  public bestSellerBrandDisplayedColumns: string[] = ['name', 'totalQuantity', 'totalAmount', 'view'];
  public ordersChartOptions: Partial<ChartOptions>;
  public customersChartOptions: Partial<ChartOptions>;

  latestOrdersDataSource = new MatTableDataSource<LatestOrderTotalOptions>(this.latestOrderTotals);
  popularKeywordDataSource = new MatTableDataSource<PopularKeywordOptions>(this.popularKeyword);
  bestCategoriesDataSource = new MatTableDataSource<BestCategoriesOptions>(this.bestCategories);
  bestSellerCategoriesDataSource = new MatTableDataSource<BestSellerCategoriesOptions>(this.bestSellerCategories);
  bestSellerBrandDataSource = new MatTableDataSource<BestSellerBrandOptions>(this.bestSellerBrand);

  constructor() {
    this.orderDisplayedColumns = this.orderColumns.map(col => col.name);
    this.ordersChartOptions = {
      series: [
        {
          name: 'Orders',
          data: [10, 41, 35, 51, 49, 62, 69, 91, 148]
        }
      ],
      chart: {
        height: 320,
        type: 'line'
      },
      title: {
        text: ''
      },
      xaxis: {
        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep']
      },
      annotation: {
        points: [
          {
            marker: {
              size: 10,
              fillColor: 'red',
              strokeColor: 'black',
              strokeWidth: 15
            }
          }
        ]

      }

    };

    this.customersChartOptions = {
      series: [
        {
          name: 'New Customers',
          data: [50, 98, 56, 23, 87, 68, 35, 54, 88]
        }
      ],
      chart: {
        height: 320,
        type: 'line'
      },
      title: {
        text: ''
      },
      xaxis: {
        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep']
      },
      annotation: {
        points: [
          {
            marker: {
              size: 10,
              fillColor: 'red',
              strokeColor: 'black',
              strokeWidth: 15
            }
          }
        ]

      }

    };
  }

  ngAfterViewInit(): void {
    this.latestOrdersDataSource.paginator = this.paginator.toArray()[0];
    this.popularKeywordDataSource.paginator = this.paginator.toArray()[1];
    this.bestCategoriesDataSource.paginator = this.paginator.toArray()[2];
    this.bestSellerCategoriesDataSource.paginator = this.paginator.toArray()[3];
    this.bestSellerBrandDataSource.paginator = this.paginator.toArray()[4];
  }
}

