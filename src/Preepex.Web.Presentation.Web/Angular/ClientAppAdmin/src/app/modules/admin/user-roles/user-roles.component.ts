import { AfterViewInit, Component, OnInit, QueryList, ViewChild, ViewChildren, ViewEncapsulation } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router, ActivatedRoute } from '@angular/router';

export type UserOptions = {
  name: string; id: string; freeShipping: boolean; taxExempt: boolean; active: boolean; isSystemRole: boolean; edit: string;
};

@Component({
  selector: 'app-user-roles',
  templateUrl: './user-roles.component.html',
  encapsulation: ViewEncapsulation.None
})
export class UserRolesComponent implements OnInit, AfterViewInit {

  @ViewChildren(MatPaginator) paginator = new QueryList<MatPaginator>();
  @ViewChild(MatSort) sort: MatSort;

  public userRoles: UserOptions[] = [
    {
      name: 'Administrators',
      id: 'b899ec30-b85a-40ab-bb1f-18a596d5c6de',
      freeShipping: false,
      taxExempt: false,
      active: true,
      isSystemRole: true,
      edit: '',
    },
    {
      name: 'Forum Moderators',
      id: 'b899ec30-b85a-40ab-bb1f-11a596d5c6de',
      freeShipping: false,
      taxExempt: false,
      active: true,
      isSystemRole: true,
      edit: '',
    },
    {
      name: 'Guests',
      id: 'b899ec30-b85a-40ab-bb1f-12a596d5c6de',
      freeShipping: false,
      taxExempt: false,
      active: true,
      isSystemRole: true,
      edit: '',
    },
    {
      name: 'Registered',
      id: 'b899ec30-b85a-40ab-bb1f-13a596d5c6de',
      freeShipping: false,
      taxExempt: false,
      active: true,
      isSystemRole: true,
      edit: '',
    },
    {
      name: 'Vendors',
      id: 'b899ec30-b85a-40ab-bb1f-14a596d5c6de',
      freeShipping: false,
      taxExempt: false,
      active: true,
      isSystemRole: true,
      edit: '',
    },
  ];

  public isLoading: boolean = false;
  public userRolesDisplayedColumns: string[] = [ 'name', 'freeShipping', 'taxExempt', 'active', 'isSystemRole', 'edit'];
  public isAllSelected: boolean;
  public userRolesDataSource = new MatTableDataSource<UserOptions>(this.userRoles);


  constructor(private router: Router,
    private _route: ActivatedRoute) { }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    this.userRolesDataSource.paginator = this.paginator.toArray()[0];
    this.userRolesDataSource.sort = this.sort;
  }

  createUserRole(): void {
    this.router.navigate(['create'], { relativeTo: this._route });
  }

  editUserRole(userId: string): void {
    this.router.navigate(['edit', userId], { relativeTo: this._route });
  }


}
