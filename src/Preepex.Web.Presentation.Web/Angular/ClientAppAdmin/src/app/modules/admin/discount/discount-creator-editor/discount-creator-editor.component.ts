import { AfterViewInit, Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { FuseConfirmationService } from '@fuse/services/confirmation';

@Component({
  selector: 'app-discount-creator-editor',
  templateUrl: './discount-creator-editor.component.html',
  encapsulation: ViewEncapsulation.None
})
export class DiscountCreatorEditorComponent implements OnInit, AfterViewInit {

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  discountUsage = [
    {
      used: 1,
      order: 's899ec30-b85a-40ab-bb1f',
      orderTotal: 2
    },
    {
      used: 5,
      order: 'b899ec30-b85a-40ab-bb1f',
      orderTotal: 2
    }
  ];

  isEdit: boolean;
  discountId: string;
  isLoading: boolean;
  discount = {
    isAdvanced: true,
    info: {
      name: '',
      discountType: 'value1',
      parentCategory: '',
      isUserPercentage: false,
      discountPercentage: '',
      discountAmount: '',
      maxDiscountAmount: '',
      isRequiredCoupen: false,
      coupenCode: '',
      startDate: '',
      endDate: '',
      isCumulative: false,
      discountLimit: 'value1',
      adminComment: '',
      coupenURL: 'https://preepex.azurewebsites.net?discountcoupon=456'
    }
  };

  public discountUsageDisplayedColumns: string[] = ['used', 'order', 'orderTotal', 'actions'];
  public discountUsageDataSource = new MatTableDataSource<any>(this.discountUsage);

  constructor(private _route: ActivatedRoute,
    private _router: Router,
    private _fuseConfirmationService: FuseConfirmationService) {
    const snapshot = this._route.snapshot;
    this.isEdit = snapshot?.data.isEdit;
    if (this.isEdit) {
      this.discountId = snapshot.params.id;
    }
  }

  ngOnInit(): void {
    if (this.isEdit) {
      // todo: fetch data from API
      this.discount.info.name = '20% order total\' discount';
    }
  }

  ngAfterViewInit(): void {
    this.discountUsageDataSource.sort = this.sort;
    this.discountUsageDataSource.paginator = this.paginator;
  }

  saveAndRedirect(): void {
    this.back();
  }

  save(): void {
    this.discountId = 'b899ec30-b85a-40ab-bb1f-18a596d5c6de';
    this.isEdit = true;
  }

  back(): void {
    const isEdit = this._route.snapshot?.data.isEdit;
    if (isEdit) {
      this._router.navigate(['../..'], { relativeTo: this._route });
    } else {
      this._router.navigate(['..'], { relativeTo: this._route });
    }
  }

  deleteDiscount(): void {
    const confirmation = this._fuseConfirmationService.open({
      title: 'Delete discount',
      message: 'Are you sure you want to remove this discount? This action cannot be undone!',
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
        // delete discount
        this.back();
      }
    });
  }

  deleteNote(): void {
    const confirmation = this._fuseConfirmationService.open({
      title: 'Delete discount',
      message: 'Are you sure you want to remove this discount? This action cannot be undone!',
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

  clearSearchFilter(): void {

  }

}
