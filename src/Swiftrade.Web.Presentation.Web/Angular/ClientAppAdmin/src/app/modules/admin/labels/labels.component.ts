import { AfterViewInit, Component, OnInit, QueryList, ViewChild, ViewChildren, ViewEncapsulation } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { FuseConfirmationService } from '@fuse/services/confirmation';

@Component({
  selector: 'app-labels',
  templateUrl: './labels.component.html',
  encapsulation: ViewEncapsulation.None
})
export class LabelsComponent implements OnInit, AfterViewInit {
  @ViewChildren(MatPaginator) paginator = new QueryList<MatPaginator>();
  @ViewChild(MatSort) sort: MatSort;

  public labels = [
    {
      name: 'Label 1',
      id: 'b899ec30-b85a-40ab-bb1f-18a596d5c6de',
      publish: true,
      order: 15,
      edit: '',
      isSelected: false
    },
    {
      name: 'Label 2',
      id: '07986d93-d4eb-4de1-9448-2538407f7254',
      publish: true,
      order: 8,
      edit: '',
      isSelected: false
    },
    {
      name: 'Label 3',
      id: 'ad12aa94-3863-47f8-acab-a638ef02a3e9',
      publish: true,
      order: 12,
      edit: '',
      isSelected: false
    },
    {
      name: 'Label 4',
      id: 'b899ec30-b85a-40ab-bb1f-19a596d5c6de',
      publish: true,
      order: 2,
      edit: '',
      isSelected: false
    },
    {
      name: 'Label 5',
      id: '07986d93-d4eb-4de1-9448-2038407f7254',
      publish: true,
      order: 5,
      edit: '',
      isSelected: false
    },
    {
      name: 'Label 6',
      id: 'ad12aa94-3863-47f8-acab-2138ef02a3e9',
      publish: true,
      order: 17,
      edit: '',
      isSelected: false
    },
    {
      name: 'Label 7',
      id: 'b899ec30-b85a-40ab-bb1f-22a596d5c6de',
      publish: true,
      order: 1,
      edit: '',
      isSelected: false
    },
    {
      name: 'Label 8',
      id: '07986d93-d4eb-4de1-9448-2338407f7254',
      publish: true,
      order: 6,
      edit: '',
      isSelected: false
    },
    {
      name: 'Label 9',
      id: 'ad12aa94-3863-47f8-acab-2438ef02a3e9',
      publish: true,
      order: 5,
      edit: '',
      isSelected: false
    },
    {
      name: 'Label 10',
      id: 'b899ec30-b85a-40ab-bb1f-25a596d5c6de',
      publish: true,
      order: 5,
      edit: '',
      isSelected: false
    },
    {
      name: 'Label 11',
      id: '07986d93-d4eb-4de1-9448-2638407f7254',
      publish: true,
      order: 5,
      edit: '',
      isSelected: false
    },
    {
      name: 'Label 12',
      id: 'ad12aa94-3863-47f8-acab-2738ef02a3e9',
      publish: true,
      order: 5,
      edit: '',
      isSelected: false
    }
  ];

  public filterValue = {
    name: '',
    publish: 'all',
  };

  public isLoading: boolean = false;
  public filteredLabels = this.labels;
  public labelsDisplayedColumns: string[] = ['select', 'name', 'publish', 'order', 'edit'];
  public isAllSelected: boolean;
  public labelsDataSource = new MatTableDataSource<any>(this.filteredLabels);


  constructor(private router: Router,
    private _route: ActivatedRoute,
    private _fuseConfirmationService: FuseConfirmationService) { }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    this.labelsDataSource.paginator = this.paginator.toArray()[0];
    this.labelsDataSource.sort = this.sort;
  }

  masterToggle(event): void {
    if (event.checked) {
      this.labels.forEach(x => x.isSelected = true);
    } else {
      this.labels.forEach(x => x.isSelected = false);
    }
  }

  toggleSelect(event, element): void {
    const foundLabel = this.labels.find(label => label.id === element.id);
    foundLabel.isSelected = event.checked;
    this.isAllSelected = this.labels.every(label => label.isSelected);
  }

  filterData(): void {
    this.filteredLabels = this.labels;
    this.labelsDataSource.filter = this.filterValue.name.trim().toLowerCase();
    switch (this.filterValue.publish) {
      case 'all':
        this.labelsDataSource.data = this.filteredLabels.filter(cat => cat);
        break;
      case 'published':
        this.labelsDataSource.data = this.filteredLabels.filter(cat => cat.publish);
        break;
      case 'unpublished':
        this.labelsDataSource.data = this.filteredLabels.filter(cat => !cat.publish);
        break;
      default:
        break;
    }
    this.labelsDataSource.paginator = this.paginator.toArray()[0];
  }

  clearSearchFilter(): void {
    this.filterValue = {
      name: '',
      publish: 'all'
    };
    this.filterData();
  }

  createLabel(): void {
    this.router.navigate(['create'], { relativeTo: this._route });
  }

  exportLabel(): void {

  }

  importLabel(): void {

  }

  deleteLabel(): void {
    const selectedLabels = this.labels.filter(b => b.isSelected);

    if (selectedLabels && selectedLabels.length) {
      const confirmation = this._fuseConfirmationService.open({
        title: 'Delete label',
        message: 'Are you sure you want to remove this label? This action cannot be undone!',
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
          // delete label
          this.labelsDataSource.data = this.labelsDataSource.data.filter(label => !label.isSelected);
        }
      });
    }
  }

  editLabel(labelId: string): void {
    this.router.navigate(['edit', labelId], { relativeTo: this._route });
  }
}
