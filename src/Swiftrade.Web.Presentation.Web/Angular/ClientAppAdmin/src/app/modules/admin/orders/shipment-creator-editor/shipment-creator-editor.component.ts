import { AfterViewInit, Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { FuseConfirmationService } from '@fuse/services/confirmation';

@Component({
  selector: 'app-shipment-creator-editor',
  templateUrl: './shipment-creator-editor.component.html',
  encapsulation: ViewEncapsulation.None
})
export class ShipmentCreatorEditorComponent implements OnInit, AfterViewInit {
  @ViewChild(MatSort) sort: MatSort;

  public isEdit: boolean;
  public orderId: string;
  public isLoading: boolean;
  public isEditPickupDate: boolean = false;
  public isEditDeliveryDate: boolean = false;

  shipment = {
    shipped: false,
    delivered: false
  };

  public shipments = [
    {
      product: 'Asus N551JK-XO076H Laptop',
      id: 'b899ec30-b85a-40ab-bb1f-18a596d5c6de',
      warehouse: '',
      sku: 'AS_551_LP',
      weight: '	7.00 [kg(s)]',
      dimensions: '7.00 x 7.00 x 7.00 [meter(s)]',
      qtyOrdered: 1,
      qtyShipped: 1,
      qtyToShip: 0,
      qtyReadyToPickup: 1
    },
    {
      product: 'Nikon D5500 DSLR - Black',
      id: '07986d93-d4eb-4de1-9448-2538407f7254',
      warehouse: '',
      sku: 'N5500DS_B',
      weight: '	7.00 [kg(s)]',
      dimensions: '2.00 x 2.00 x 2.00 [meter(s)]',
      qtyOrdered: 1,
      qtyShipped: 1,
      qtyToShip: 0,
      qtyReadyToPickup: 1
    }
  ];

  public shipmentsDisplayedColumns: string[] ;
  public shipmentsDataSource = new MatTableDataSource<any>(this.shipments);

  constructor(private _route: ActivatedRoute,
    private _fuseConfirmationService: FuseConfirmationService,
    private _router: Router,) {
    const snapshot = this._route.snapshot;
    this.isEdit = snapshot?.data.isEdit;
    this.orderId = snapshot.params.id;
  }

  ngOnInit(): void {
    if(this.isEdit) {
      this.shipmentsDisplayedColumns = ['product', 'sku', 'warehouse', 'weight', 'dimensions',  'qtyReadyToPickup'];
    } else {
      this.shipmentsDisplayedColumns = ['product', 'sku', 'warehouse', 'weight', 'dimensions', 'qtyOrdered', 'qtyShipped', 'qtyToShip'];
    }
  }

  ngAfterViewInit(): void {
    this.shipmentsDataSource.sort = this.sort;
  }

  public back(): void {
    this._router.navigate(['orders/edit', this.orderId]);
  }

  public saveAndRedirect(): void {
    this.back();
  }

  public save(): void {
    this.back();
  }

  public deleteShipment(): void {
    const confirmation = this._fuseConfirmationService.open({
      title: 'Delete shipment',
      message: 'Are you sure you want to remove this shipment? This action cannot be undone!',
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
        // delete shipment
        this.back();
      }
    });
  }

}
