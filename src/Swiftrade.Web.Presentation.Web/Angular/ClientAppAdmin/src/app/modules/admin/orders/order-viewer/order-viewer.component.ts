import { Component, OnInit, TemplateRef, ViewEncapsulation } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { FuseConfirmationService } from '@fuse/services/confirmation';

@Component({
  selector: 'app-order-viewer',
  templateUrl: './order-viewer.component.html',
  encapsulation: ViewEncapsulation.None
})
export class OrderViewerComponent implements OnInit {

  public isEdit: boolean;
  public orderId: string;
  public isLoading: boolean;
  public isEditOrderStatus: boolean = false;
  public isEditOrderTotals: boolean = false;
  public isShippingMethod: boolean = false;

  public order = {
    orderNumber: 1,
    orderStatus: 'complete',
    paymentStatus: 'paid',
    shippingStatus: 'delivered',
    billingEmailAddress: 'victoria_victoria@nopCommerce.com',
    createdOn: '01/12/2022 4:32:09 PM',
    orderTotal: 43.50,
    taxValue: 0.0000,
    isSelected: false
  };

  newOrderNote = {
    note: '',
    attachFile: false,
    useDownloadUrl: false,
    downloadUrl: '',
    displayToCustome: false
  };

  constructor(private _route: ActivatedRoute,
    private _router: Router,
    private matDialog: MatDialog,
    private _fuseConfirmationService: FuseConfirmationService) {
    const snapshot = this._route.snapshot;
    this.isEdit = snapshot?.data.isEdit;
    if (this.isEdit) {
      this.orderId = snapshot.params.id;
    }
  }

  ngOnInit(): void {
  }

  printInvoice(): void {

  }

  public back(): void {
    if (this.isEdit) {
      this._router.navigate(['../..'], { relativeTo: this._route });
    } else {
      this._router.navigate(['..'], { relativeTo: this._route });
    }
  }

  public editAddress(): void {
    this._router.navigate(['orders/editAddress', this.orderId]);
  }

  public addShipment(): void {
    this._router.navigate(['orders/addShipment', this.orderId]);
  }

  public addProduct(): void {
    this._router.navigate(['orders/addProduct', this.orderId]);
  }

  public deleteOrder(): void {
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
        this.back();
      }
    });
  }

  public fullRefund(): void {
    const confirmation = this._fuseConfirmationService.open({
      title: 'Are you sure?',
      message: 'Are you sure you want to perform this action?',
      actions: {
        confirm: {
          label: 'Yes'
        }
      }
    });
  }

  public openPartialRefundModal(ref: TemplateRef<any>): void {
    this.matDialog.open(ref, {
      width: '60vw',
      maxHeight: '90vh'
    });
  }

  public changeOrderStatus(): void {
    this.isEditOrderStatus = !this.isEditOrderStatus;
  }

}
