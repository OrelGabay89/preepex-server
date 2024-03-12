import { Component, OnInit, TemplateRef, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { FuseConfirmationService } from '@fuse/services/confirmation';

@Component({
  selector: 'app-user-roles-creator-editor',
  templateUrl: './user-roles-creator-editor.component.html',
  encapsulation: ViewEncapsulation.None
})
export class UserRolesCreatorEditorComponent implements OnInit {

  @ViewChild('productPaginator') productPaginator: MatPaginator;
  @ViewChild('productTableSort') productTableSort: MatSort;

  isEdit: boolean;
  userRoleId: string;
  isLoading: boolean;
  userRole = {
    info: {
      name: '',
      active: true,
      freeShipping: false,
      taxExempt: false,
      defaultTax: false,
      lifetimePassword: false,
      isSystemRole: 'No',
      systemName: ''
    }
  };

  products = [
    {
      id: 'b899ec30-b85a-40ab-bb1f-18a596d5c6de',
      name: 'Build your own computer',
      publish: true,
      isSelected: false,
      featured: false,
      order: 1
    },
    {
      id: 'b899ec33-b85a-40ab-bb1f-18a596d5c6de',
      name: 'Asus N551JK-XO076H Laptop',
      publish: true,
      isSelected: false,
      featured: false,
      order: 1
    },
    {
      id: 'b899ec30-b85a-40ab-bb1t-18a596d5c6de',
      name: 'HP Spectre XT Pro UltraBook',
      publish: true,
      isSelected: false,
      featured: false,
      order: 1
    },
    {
      id: 'b899ec30-b85a-40ab-bb1f-18a596d5d6de',
      name: 'Lenovo IdeaCentre 600 All-in-One PC',
      publish: true,
      isSelected: false,
      featured: false,
      order: 1
    },
    {
      id: 'b899ec30-g85a-40ab-bb1f-18a596d5c6de',
      name: 'Digital Storm VANQUISH 3 Custom Performance PC',
      publish: true,
      isSelected: false,
      featured: false,
      order: 1
    },
    {
      id: 'b899ec30-b85a-40ab-bb1t-18a5w6d5c6de',
      name: 'HP Spectre XT Pro UltraBook 1',
      publish: true,
      isSelected: false,
      featured: false,
      order: 1
    },
    {
      id: 'b899ef30-b85a-40ab-bb1f-18a596d5d6de',
      name: 'Lenovo IdeaCentre 600 All-in-One PC 2',
      publish: true,
      isSelected: false,
      featured: false,
      order: 1
    },
    {
      id: 'b899ec30-b85a-40ab-bb1t-18a59sd5c6de',
      name: 'HP Spectre XT Pro UltraBook 3',
      publish: true,
      isSelected: false,
      featured: false,
      order: 1
    },
    {
      id: 'b899ec30-b85a-40ab-bb1f-18a596y5d6de',
      name: 'Lenovo IdeaCentre 600 All-in-One PC 4',
      publish: true,
      isSelected: false,
      featured: false,
      order: 1
    },
  ];
  selectedProduct: any;

  productDataSource = new MatTableDataSource<any>();

  public productDisplayedColumns: string[] = ['select', 'name', 'publish'];


  constructor(private _route: ActivatedRoute,
    private matDialog: MatDialog,
    private _router: Router,
    private _fuseConfirmationService: FuseConfirmationService) {
    const snapshot = this._route.snapshot;
    this.isEdit = snapshot?.data.isEdit;
    if (this.isEdit) {
      this.userRoleId = snapshot.params.id;
    }
  }

  ngOnInit(): void {
    if (this.isEdit) {
      // todo: fetch data from API
    }
    this.productDataSource.data = this.products;
  }

  saveAndRedirect(): void {
    this.back();
  }

  save(): void {
    this.userRoleId = 'b899ec30-b85a-40ab-bb1f-18a596d5c6de';
    this.isEdit = true;
  }

  back(): void {
    if (this.isEdit) {
      this._router.navigate(['../..'], { relativeTo: this._route });
    } else {
      this._router.navigate(['..'], { relativeTo: this._route });
    }
  }

  openUserRoleTable(ref: TemplateRef<any>): void {
    this.matDialog.open(ref, {
      width: '80vw',
      maxHeight: '90vh'
    });

    setTimeout(() => {
      this.productDataSource.sort = this.productTableSort;
      this.productDataSource.paginator = this.productPaginator;
    });
  }

  saveProduct(productId: string): void {
    this.selectedProduct = this.products.find(p => p.id === productId);
    this.matDialog.closeAll();
  }

  removeUserRoleTable(): void {
    this.selectedProduct = null;
  }

  deleteUserRole(): void {
    const confirmation = this._fuseConfirmationService.open({
      title: 'Delete user role',
      message: 'Are you sure you want to remove this user role? This action cannot be undone!',
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
        // delete user role
        this.back();
      }
    });
  }

  clearSearchFilter(): void {

  }

}
