import { AfterViewInit, Component, OnInit, QueryList, ViewChild, ViewChildren, ViewEncapsulation } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { FuseConfirmationService } from '@fuse/services/confirmation';

@Component({
  selector: 'app-newsletter',
  templateUrl: './newsletter.component.html',
  encapsulation: ViewEncapsulation.None
})
export class NewsletterComponent implements OnInit, AfterViewInit {
  @ViewChildren(MatPaginator) paginator = new QueryList<MatPaginator>();
  @ViewChild(MatSort) sort: MatSort;

  public newsletters = [
    {
      email: 'dejesusmichael@mail.org',
      id: 'b899ec30-b85a-40ab-bb1f-18a596d5c6de',
      active: true,
      edit: '',
      subscribedOn: new Date(),
      delete: '',
    },
    {
      email: 'michael.dejesus@vitricomp.io',
      id: '07986d93-d4eb-4de1-9448-2538407f7254',
      active: true,
      edit: '',
      subscribedOn: new Date(),
      delete: '',
    }
  ];

  public isLoading: boolean = false;
  public filteredNewsletters = this.newsletters;
  public newsDisplayedColumns: string[] = ['email', 'active', 'subscribedOn', 'edit', 'delete'];
  public newsDataSource = new MatTableDataSource<any>(this.filteredNewsletters);

  public filterValue = {
    email: '',
    active: 'all',
    startDate: null,
    endDate: null,
    customerRoles: 'all'
  };

  constructor(
    private _fuseConfirmationService: FuseConfirmationService) { }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    this.newsDataSource.paginator = this.paginator.toArray()[0];
    this.newsDataSource.sort = this.sort;
  }

  filterData(): void {

  }

  clearSearchFilter(): void {

  }

  deleteNewsletter(): void {
    const confirmation = this._fuseConfirmationService.open({
      title: 'Delete newsletter',
      message: 'Are you sure you want to remove this newsletter? This action cannot be undone!',
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
        // delete
        // this.back();
      }
    });
  }

  editNewsletter(newsletterId: string): void {

  }

}
