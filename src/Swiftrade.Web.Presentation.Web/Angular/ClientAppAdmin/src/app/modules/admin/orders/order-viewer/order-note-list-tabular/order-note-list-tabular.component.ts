import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { FuseConfirmationService } from '@fuse/services/confirmation';

class OrderNote {
  createdOn: string;
  note: string;
  attachedFiles: string;
  displayToCustomer: boolean;
}

@Component({
  selector: 'order-order-note-list-tabular',
  templateUrl: './order-note-list-tabular.component.html'
})
export class OrderNoteListTabularComponent implements OnInit, AfterViewInit {

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  orderNotes = [
    {
      createdOn: '03/24/2022 10:17:29 AM',
      note: 'A new order item has been added',
      attachedFiles: '',
      displayToCustomer: false
    },
    {
      createdOn: '01/12/2022 4:32:09 PM',
      note: 'Order placed',
      attachedFiles: '',
      displayToCustomer: false
    },
    {
      createdOn: '01/12/2022 4:32:09 PM',
      note: 'Order paid',
      attachedFiles: '',
      displayToCustomer: false
    },
    {
      createdOn: '01/12/2022 4:32:09 PM',
      note: 'Order shipped',
      attachedFiles: '',
      displayToCustomer: false
    },
    {
      createdOn: '01/12/2022 4:32:09 PM',
      note: 'Order delivered',
      attachedFiles: '',
      displayToCustomer: false
    }
  ];

  public orderNoteDisplayedColumns: string[] = ['createdOn', 'note', 'attachedFiles', 'displayToCustomer', 'actions'];
  public orderNoteDataSource = new MatTableDataSource<OrderNote>(this.orderNotes);

  constructor(private _fuseConfirmationService: FuseConfirmationService) { }

  ngAfterViewInit(): void {
    this.orderNoteDataSource.sort = this.sort;
    this.orderNoteDataSource.paginator = this.paginator;
  }

  ngOnInit(): void {
  }

  deleteNote(): void {
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
