import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { FuseConfirmationService } from '@fuse/services/confirmation';

class Product {
  picture: string;
  name: string;
  sku: string;
  price: number;
  quantity: number;
  discount: number;
  total: number;
}

@Component({
  selector: 'order-product-list-tabular',
  templateUrl: './product-list-tabular.component.html',
  styles: [
    `.mat-column-picture {
      width: 10%;
    }
    .mat-column-name, .mat-column-price, .mat-column-discount, .mat-column-total {
      width: 20%;
    }
    .mat-column-actions {
      width: 10%;
    }
    `
  ]
})
export class ProductListTabularComponent implements OnInit, AfterViewInit {

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  products = [
    {
      picture: '',
      name: 'Levi\'s 511 Jeans',
      sku: 'LV_511_JN',
      price: 43.50,
      quantity: 1,
      discount: 0,
      total: 43.50
    },
    {
      picture: '',
      name: 'Asus N551JK-XO076H Laptop',
      sku: 'AS_551_LP',
      price: 1500.00,
      quantity: 1,
      discount: 0,
      total: 1500.00
    }
  ];

  public selectedProductIndex: number;

  public productDisplayedColumns: string[] = ['picture', 'name', 'price', 'quantity', 'discount', 'total', 'actions'];
  public productDataSource = new MatTableDataSource<Product>(this.products);

  constructor(private _fuseConfirmationService: FuseConfirmationService) { }

  ngAfterViewInit(): void {
    this.productDataSource.sort = this.sort;
    this.productDataSource.paginator = this.paginator;
  }

  ngOnInit(): void {
  }

  editProduct(index: number): void {
    this.selectedProductIndex = index;
  }

  cancelEditing(): void {
    this.selectedProductIndex = undefined;
  }

  saveProduct(): void {
    this.selectedProductIndex = undefined;
  }

  deleteProduct(): void {
    const confirmation = this._fuseConfirmationService.open({
      title: 'Delete order',
      message: 'Are you sure you want to remove this order? This action cannot be undone!',
      actions: {
        confirm: {
          label: 'Delete'
        }
      }
    });

    // Subscribe to the confirmation dialog closed action
    confirmation.afterClosed().subscribe((result) => {

      // If the confirm button pressed...
      if (result === 'confirmed') {
        // delete brand
        // this.back();
      }
    });
  }
}
