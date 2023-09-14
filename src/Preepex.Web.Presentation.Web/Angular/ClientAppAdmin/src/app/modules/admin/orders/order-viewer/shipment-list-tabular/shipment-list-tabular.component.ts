import { trigger, state, style, transition, animate } from '@angular/animations';
import { AfterViewInit, ChangeDetectorRef, Component, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';

class Shipment {
  id: string;
  shipmentNumber: number;
  orderNumber: number;
  trackingNumber: number;
  totalWeight: string;
  shippedDate: string;
  deliveredDate: string;
  products: any;
}

class Product {
  name: string;
  warehouse: string;
  quantityShipped: number;
  itemWeight: string;
  itemDimentions: string;
}

@Component({
  selector: 'order-shipment-list-tabular',
  templateUrl: './shipment-list-tabular.component.html',
  styles: [
    `
    tr.example-detail-row {
        height: 0;
    }
    .example-element-row td {
        border-bottom-width: 0;
    }`
  ],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class ShipmentListTabularComponent implements OnInit, AfterViewInit {

  @ViewChild('outerSort') sort: MatSort;
  @ViewChildren('innerSort') innerSort: QueryList<MatSort>;
  @ViewChildren('innerTables') innerTables: QueryList<MatTable<Product>>;

  @ViewChild('shipmentPaginator') shipmentPaginator: MatPaginator;
  @ViewChildren('productPaginator') productPaginators: QueryList<MatPaginator>;

  shipments: Shipment[] = [
    {
      id: 'b899ec30-b85a-40ab-bb1f-18a596d5c6de',
      shipmentNumber: 3,
      orderNumber: 5,
      trackingNumber: 56,
      totalWeight: '2.00 [kg(s)]',
      shippedDate: '1/12/2022 4:32:09 PM',
      deliveredDate: '1/12/2022 4:32:09 PM',
      products: [
        {
          name: 'Levi\'s 511 Jeans',
          warehouse: '',
          quantityShipped: 1,
          itemWeight: '',
          itemDimentions: '2.00 x 2.00 x 2.00 [meter(s)]'
        },
        {
          name: 'Levi\'s 511 Shirt',
          warehouse: '',
          quantityShipped: 1,
          itemWeight: '',
          itemDimentions: '2.00 x 2.00 x 2.00 [meter(s)]'
        }
      ]
    },
    {
      id: 'b899ec30-b85a-40ab-bb1f-18a596d7c6de',
      shipmentNumber: 4,
      orderNumber: 6,
      trackingNumber: 57,
      totalWeight: '2.00 [kg(s)]',
      shippedDate: '1/12/2022 4:32:09 PM',
      deliveredDate: '1/12/2022 4:32:09 PM',
      products: [
        {
          name: 'Levi\'s 511 Jeans',
          warehouse: '',
          quantityShipped: 1,
          itemWeight: '',
          itemDimentions: '2.00 x 2.00 x 2.00 [meter(s)]'
        }
      ]
    }
  ];

  public shipmentDisplayedColumns: string[] = ['expandAction', 'shipmentNumber', 'orderNumber', 'trackingNumber', 'totalWeight', 'shippedDate', 'deliveredDate', 'viewAction'];
  public productDisplayedColumns: string[] = ['name', 'warehouse', 'quantityShipped', 'itemWeight', 'itemDimentions'];

  public shipmentDataSource = new MatTableDataSource<Shipment>();

  shipmentsData: Shipment[] = [];

  expandedElement: Shipment;



  constructor(private cd: ChangeDetectorRef, private _router: Router,) { }

  ngAfterViewInit(): void {
    this.shipmentDataSource.sort = this.sort;
    this.shipmentDataSource.paginator = this.shipmentPaginator;
  }

  ngOnInit(): void {
    this.shipments.forEach((shipment) => {
      if (shipment.products && Array.isArray(shipment.products) && shipment.products.length) {
        this.shipmentsData = [...this.shipmentsData, { ...shipment, products: new MatTableDataSource(shipment.products) }];
      } else {
        this.shipmentsData = [...this.shipmentsData, shipment];
      }
    });
    this.shipmentDataSource = new MatTableDataSource(this.shipmentsData);
    this.shipmentDataSource.sort = this.sort;
    this.shipmentDataSource.paginator = this.shipmentPaginator;
  }

  public editShipment(orderId): void {
    this._router.navigate(['orders/editShipment', orderId]);
  }

  public toggleRow(element: Shipment): void {
    if (element.products && (element.products as MatTableDataSource<Product>).data.length) {
      this.expandedElement = this.expandedElement && this.expandedElement.id === element.id ? null : element;
    }
    this.cd.detectChanges();
    this.innerTables.forEach((table, index) => {
      (table.dataSource as MatTableDataSource<Product>).sort = this.innerSort.toArray()[index];
      (table.dataSource as MatTableDataSource<Product>).paginator = this.productPaginators.toArray()[index];
    });
  }
}
