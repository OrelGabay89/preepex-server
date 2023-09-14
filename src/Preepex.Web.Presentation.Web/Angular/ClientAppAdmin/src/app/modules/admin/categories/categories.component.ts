import { AfterViewInit, Component, OnInit, QueryList, ViewChild, ViewChildren, ViewEncapsulation } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { FuseConfirmationService } from '@fuse/services/confirmation';

export type CategoryOptions = {
  name: string; id: string; publish: boolean; order: number; edit: string; isSelected: boolean;
};

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  encapsulation: ViewEncapsulation.None
})
export class CategoriesComponent implements OnInit, AfterViewInit {
  @ViewChildren(MatPaginator) paginator = new QueryList<MatPaginator>();
  @ViewChild(MatSort) sort: MatSort;

  public categories = [
    {
      name: 'Mens >> Shirts >> undershirt',
      id: 'b899ec30-b85a-40ab-bb1f-18a596d5c6de',
      publish: true,
      order: 5,
      edit: '',
      isSelected: false
    },
    {
      name: 'Ladies >> Shirts >> Sports shirt',
      id: '07986d93-d4eb-4de1-9448-2538407f7254',
      publish: true,
      order: 2,
      edit: '',
      isSelected: false
    },
    {
      name: 'Unisex >> Shirts >> undershirt',
      id: 'ad12aa94-3863-47f8-acab-a638ef02a3e9',
      publish: true,
      order: 8,
      edit: '',
      isSelected: false
    },
    {
      name: 'Mens>> Shirts >> Polo shirt',
      id: 'b899ec30-b85a-40ab-bb1f-19a596d5c6de',
      publish: true,
      order: 5,
      edit: '',
      isSelected: false
    },
    {
      name: 'Ladies >> Shirts >> undershirt',
      id: '07986d93-d4eb-4de1-9448-2038407f7254',
      publish: true,
      order: 5,
      edit: '',
      isSelected: false
    },
    {
      name: 'Unisex >> Pants >> Shorts pants',
      id: 'ad12aa94-3863-47f8-acab-2138ef02a3e9',
      publish: true,
      order: 5,
      edit: '',
      isSelected: false
    },
    {
      name: 'Mens >> Shirts >> undershirt',
      id: 'b899ec30-b85a-40ab-bb1f-22a596d5c6de',
      publish: true,
      order: 5,
      edit: '',
      isSelected: false
    },
    {
      name: 'Ladies>> Pants >> sports pants',
      id: '07986d93-d4eb-4de1-9448-2338407f7254',
      publish: true,
      order: 5,
      edit: '',
      isSelected: false
    },
    {
      name: 'Unisex',
      id: 'ad12aa94-3863-47f8-acab-2438ef02a3e9',
      publish: true,
      order: 5,
      edit: '',
      isSelected: false
    },
    {
      name: 'Mens>> Pants >> sports pants',
      id: 'b899ec30-b85a-40ab-bb1f-25a596d5c6de',
      publish: true,
      order: 5,
      edit: '',
      isSelected: false
    },
    {
      name: 'Ladies >> Pants >> Shorts pants',
      id: '07986d93-d4eb-4de1-9448-2638407f7254',
      publish: true,
      order: 5,
      edit: '',
      isSelected: false
    },
    {
      name: 'Unisex>> Shirts >> Polo shirt',
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
  public filteredCategories = this.categories;
  public categoriesDisplayedColumns: string[] = ['select', 'name', 'publish', 'order', 'edit'];
  public isAllSelected: boolean;
  public categoriesDataSource = new MatTableDataSource<CategoryOptions>(this.filteredCategories);

  constructor(
    private _router: Router,
    private _route: ActivatedRoute,
    private _fuseConfirmationService: FuseConfirmationService
  ) {

  }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    this.categoriesDataSource.paginator = this.paginator.toArray()[0];
    this.categoriesDataSource.sort = this.sort;
  }

  masterToggle(event): void {
    if (event.checked) {
      this.categories.forEach(x => x.isSelected = true);
    } else {
      this.categories.forEach(x => x.isSelected = false);
    }
  }

  toggleSelect(event, element): void {
    const foundCategory = this.categories.find(cat => cat.id === element.id);
    foundCategory.isSelected = event.checked;
    this.isAllSelected = this.categories.every(cat => cat.isSelected);
  }

  filterData(): void {
    this.filteredCategories = this.categories;
    this.categoriesDataSource.filter = this.filterValue.name.trim().toLowerCase();
    switch (this.filterValue.publish) {
      case 'all':
        this.categoriesDataSource.data = this.filteredCategories.filter(cat => cat);
        break;
      case 'published':
        this.categoriesDataSource.data = this.filteredCategories.filter(cat => cat.publish);
        break;
      case 'unpublished':
        this.categoriesDataSource.data = this.filteredCategories.filter(cat => !cat.publish);
        break;
      default:
        break;
    }
    this.categoriesDataSource.paginator = this.paginator.toArray()[0];
  }

  clearSearchFilter(): void {
    this.filterValue =  {
      name: '',
      publish: 'all'
    };
    this.filterData();
  }

  editCategory(categoryId: string): void {
    this._router.navigate(['edit', categoryId], { relativeTo: this._route });
  }

  createCategory(): void {
    this._router.navigate(['create'], { relativeTo: this._route });
  }

  exportCategory(): void {

  }

  importCategory(): void {

  }

  deleteCategory(): void {
    const selectedCategories = this.categories.filter(c => c.isSelected);

    if (selectedCategories && selectedCategories.length) {
      const confirmation = this._fuseConfirmationService.open({
        title: 'Delete category',
        message: 'Are you sure you want to remove this category? This action cannot be undone!',
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
          this.categoriesDataSource.data = this.categoriesDataSource.data.filter(cat => !cat.isSelected);
        }
      });
    }
  }

}
