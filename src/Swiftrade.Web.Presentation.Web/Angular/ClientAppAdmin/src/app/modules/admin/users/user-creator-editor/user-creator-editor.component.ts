import { AfterViewInit, Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { FuseConfirmationService } from '@fuse/services/confirmation';

@Component({
  selector: 'app-user-creator-editor',
  templateUrl: './user-creator-editor.component.html',
  encapsulation: ViewEncapsulation.None
})
export class UserCreatorEditorComponent implements OnInit, AfterViewInit {

  @ViewChild('ordersPaginator') ordersPaginator: MatPaginator;

  @ViewChild('ordersTableSort') ordersTableSort: MatSort;


  isEdit: boolean;
  userId: string;
  isLoading: boolean;
  user = {
    info: {
      email: '',
      password: '',
      first: '',
      last: '',
      gender: '',
      company: '',
      tax: false,
      newsletter: '',
      roles: '',
      vendor: '',
      active: true,
      adminComment: '',
    }
  };

  public isAllSelected: boolean;


  ordersDataSource = new MatTableDataSource<any>();

  public ordersDisplayedColumns: string[] = ['index', 'orderTotal', 'orderStatus', 'paymentStatus', 'shippingStatus', 'createdOn', 'view'];

  constructor(private _route: ActivatedRoute,
    private _router: Router,
    private _fuseConfirmationService: FuseConfirmationService) {
    const snapshot = this._route.snapshot;
    this.isEdit = snapshot?.data.isEdit;
    if (this.isEdit) {
      this.userId = snapshot.params.id;
    }
  }

  ngOnInit(): void {
    if (this.isEdit) {
      // todo: fetch data from API
    }
  }

  ngAfterViewInit(): void {
    this.ordersDataSource.paginator = this.ordersPaginator;
    this.ordersDataSource.sort = this.ordersTableSort;
  }

  saveAndRedirect(): void {
    this.back();
  }

  save(): void {
    this.userId = 'b899ec30-b85a-40ab-bb1f-18a596d5c6de';
    this.isEdit = true;
  }

  back(): void {
    if (this.isEdit) {
      this._router.navigate(['../..'], { relativeTo: this._route });
    } else {
      this._router.navigate(['..'], { relativeTo: this._route });
    }
  }

  deleteBrand(): void {
    const confirmation = this._fuseConfirmationService.open({
      title: 'Delete user',
      message: 'Are you sure you want to remove this user? This action cannot be undone!',
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
        // delete user
        this.back();
      }
    });
  }

  sendEmail(): void {

  }


  clearSearchFilter(): void {

  }

}
