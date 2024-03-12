import { AfterViewInit, Component, OnInit, QueryList, ViewChild, ViewChildren, ViewEncapsulation } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router, ActivatedRoute } from '@angular/router';
import { FuseConfirmationService } from '@fuse/services/confirmation';

export type UserOptions = {
  email: string; name: string; id: string; role: string; company: string; ipAddress: string; active: boolean; edit: string; isSelected: boolean;
};

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  encapsulation: ViewEncapsulation.None
})
export class UsersComponent implements OnInit, AfterViewInit {
  @ViewChildren(MatPaginator) paginator = new QueryList<MatPaginator>();
  @ViewChild(MatSort) sort: MatSort;

  public users: UserOptions[] = [
    {
      name: 'Steve Gates',
      email: 'steve_gates@nopCommerce.com',
      role: 'Registered',
      id: 'b899ec30-b85a-40ab-bb1f-18a596d5c6de',
      company: 'Swiftrade',
      ipAddress: '45261',
      active: true,
      edit: '',
      isSelected: false
    },
    {
      name: '	Arthur Holmes',
      email: 'arthur_holmes@nopCommerce.com',
      role: 'Registered',
      id: 'b899ec30-b85a-50ab-bb1f-18a596d5c6de',
      company: 'Swiftrade',
      ipAddress: '45262',
      active: true,
      edit: 'Registered',
      isSelected: false
    },
    {
      name: 'James Pan',
      email: 'james_pan@nopCommerce.com',
      role: 'Forum Moderators',
      id: 'b899ec30-b85a-60ab-bb1f-18a596d5c6de',
      company: 'Swiftrade',
      ipAddress: '45266',
      active: true,
      edit: '',
      isSelected: false
    },
    {
      name: 'Brenda Lindgren',
      email: 'brenda_lindgren@nopCommerce.com',
      role: 'Administrators, Registered',
      id: 'b899ec30-b85a-70ab-bb1f-18a596d5c6de',
      company: 'Swiftrade',
      ipAddress: '45266',
      active: true,
      edit: '',
      isSelected: false
    },
    {
      name: 'Victoria Terces',
      email: 'victoria_victoria@nopCommerce.com',
      role: 'Administrators',
      id: 'b899ec30-b85a-80ab-bb1f-18a596d5c6de',
      company: 'Swiftrade',
      ipAddress: '45266',
      active: true,
      edit: '',
      isSelected: false
    },
    {
      name: 'John Smith',
      email: 'admin@preepex.com',
      role: 'Registered',
      id: 'b899ec30-b85a-90ab-bb2f-18a596d5c6de',
      company: 'Swiftrade',
      ipAddress: '45266',
      active: true,
      edit: '',
      isSelected: false
    },
    {
      name: 'Guest',
      email: 'guest@preepex.com',
      role: 'Guests',
      id: 'b899ec30-b85a-90ab-bb3f-18a596d5c6de',
      company: 'Swiftrade',
      ipAddress: '45266',
      active: true,
      edit: '',
      isSelected: false
    },
    {
      name: 'Guest',
      email: 'guest@preepex.com',
      role: 'Guests',
      id: 'b899ec30-b85a-90ab-bb4f-18a596d5c6de',
      company: 'Swiftrade',
      ipAddress: '45266',
      active: true,
      edit: '',
      isSelected: false
    },
    {
      name: 'Guest',
      email: 'guest@preepex.com',
      role: 'Guests',
      id: 'b899ec30-b85a-90ab-bb5f-18a596d5c6de',
      company: 'Swiftrade',
      ipAddress: '45266',
      active: true,
      edit: '',
      isSelected: false
    },
    {
      name: 'Guest',
      email: 'guest@preepex.com',
      role: 'Guests',
      id: 'b899ec30-b85a-90ab-bb6f-18a596d5c6de',
      company: 'Swiftrade',
      ipAddress: '45266',
      active: true,
      edit: '',
      isSelected: false
    },
    {
      name: 'Guest',
      email: 'guest@preepex.com',
      role: 'Guests',
      id: 'b899ec30-b85a-90ab-bb7f-18a596d5c6de',
      company: 'Swiftrade',
      ipAddress: '45266',
      active: true,
      edit: '',
      isSelected: false
    },
    {
      name: 'Guest',
      email: 'guest@preepex.com',
      role: 'Guests',
      id: 'b899ec30-b85a-90ab-bb8f-18a596d5c6de',
      company: 'Swiftrade',
      ipAddress: '45266',
      active: true,
      edit: '',
      isSelected: false
    },
    {
      name: 'Guest',
      email: 'guest@preepex.com',
      role: 'Guests',
      id: 'b899ec30-b85a-90ab-bb9f-18a596d5c6de',
      company: 'Swiftrade',
      ipAddress: '45266',
      active: true,
      edit: '',
      isSelected: false
    },
    {
      name: 'Guest',
      email: 'guest@preepex.com',
      role: 'Guests',
      id: 'b899ec30-b85a-90ab-bb1f-18a596d6c6de',
      company: 'Swiftrade',
      ipAddress: '45266',
      active: true,
      edit: '',
      isSelected: false
    },
    {
      name: 'Guest',
      email: 'guest@preepex.com',
      role: 'Guests',
      id: 'b899ec30-b85a-90ab-bb1f-18a596d7c6de',
      company: 'Swiftrade',
      ipAddress: '45266',
      active: true,
      edit: '',
      isSelected: false
    }
  ];

  public filterValue = {
    email: '',
    company: '',
    name: '',
    ipAddress: '',
    role: [],
  };

  public isLoading: boolean = false;
  public filteredUsers = this.users;
  public usersDisplayedColumns: string[] = ['select', 'email', 'name', 'role', 'company', 'active', 'view', 'edit', 'delete'];
  public isAllSelected: boolean;
  public usersDataSource = new MatTableDataSource<UserOptions>(this.filteredUsers);

  constructor(private router: Router,
    private _route: ActivatedRoute,
    private _fuseConfirmationService: FuseConfirmationService) { }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    this.usersDataSource.paginator = this.paginator.toArray()[0];
    this.usersDataSource.sort = this.sort;
  }

  masterToggle(event): void {
    if (event.checked) {
      this.users.forEach(x => x.isSelected = true);
    } else {
      this.users.forEach(x => x.isSelected = false);
    }
  }

  toggleSelect(event, element): void {
    const foundUser = this.users.find(user => user.id === element.id);
    foundUser.isSelected = event.checked;
    this.isAllSelected = this.users.every(user => user.isSelected);
  }

  filterData(): void {
    this.usersDataSource.data = this.users;
    if (this.filterValue.email) {
      this.usersDataSource.data = this.usersDataSource.data.filter(user => user.email.toLowerCase().includes(this.filterValue.email.toLowerCase()));
    }
    if (this.filterValue.company) {
      this.usersDataSource.data = this.usersDataSource.data.filter(user => user.company.toLowerCase().includes(this.filterValue.company.toLowerCase()));
    }
    if (this.filterValue.name) {
      this.usersDataSource.data = this.usersDataSource.data.filter(user => user.name.toLowerCase().includes(this.filterValue.name.toLowerCase()));
    }
    if (this.filterValue.ipAddress) {
      this.usersDataSource.data = this.usersDataSource.data.filter(user => user.ipAddress.toLowerCase().includes(this.filterValue.ipAddress.toLowerCase()));
    }
    if (this.filterValue.role && this.filterValue.role.length) {
      this.usersDataSource.data = this.usersDataSource.data.filter(user => this.filterValue.role.some(r => r.toLowerCase().includes(user.role.toLowerCase())));
    }
  }

  clearSearchFilter(): void {
    this.filterValue = {
      email: '',
      company: '',
      name: '',
      ipAddress: '',
      role: [],
    };
    this.usersDataSource.data = this.users;
  }

  createUser(): void {
    this.router.navigate(['create'], { relativeTo: this._route });
  }

  exportUser(): void {

  }

  importUser(): void {

  }

  deleteUser(id: string): void {
    const selectedUser = this.users.filter(b => b.id === id);

    if (selectedUser) {
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
          this.usersDataSource.data = this.usersDataSource.data.filter(user => user.id !== id);
        }
      });
    }

  }


  editUser(userId: string): void {
    this.router.navigate(['edit', userId], { relativeTo: this._route });
  }

}
