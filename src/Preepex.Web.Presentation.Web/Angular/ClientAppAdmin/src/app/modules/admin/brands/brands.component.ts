import { AfterViewInit, Component, OnInit, QueryList, ViewChild, ViewChildren, ViewEncapsulation } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { FuseConfirmationService } from '@fuse/services/confirmation';

export type BrandOptions = {
  name: string; id: string; publish: boolean; order: number; edit: string; isSelected: boolean;
};

@Component({
  selector: 'app-brands',
  templateUrl: './brands.component.html',
  encapsulation: ViewEncapsulation.None
})
export class BrandsComponent implements OnInit, AfterViewInit {
  @ViewChildren(MatPaginator) paginator = new QueryList<MatPaginator>();
  @ViewChild(MatSort) sort: MatSort;

  public brands = [
    {
      name: 'Benton',
      id: 'b899ec30-b85a-40ab-bb1f-18a596d5c6de',
      publish: true,
      order: 15,
      edit: '',
      isSelected: false
    },
    {
      name: 'Capmia',
      id: '07986d93-d4eb-4de1-9448-2538407f7254',
      publish: true,
      order: 8,
      edit: '',
      isSelected: false
    },
    {
      name: 'Lara',
      id: 'ad12aa94-3863-47f8-acab-a638ef02a3e9',
      publish: true,
      order: 12,
      edit: '',
      isSelected: false
    },
    {
      name: 'Puma',
      id: 'b899ec30-b85a-40ab-bb1f-19a596d5c6de',
      publish: true,
      order: 2,
      edit: '',
      isSelected: false
    },
    {
      name: 'Nike',
      id: '07986d93-d4eb-4de1-9448-2038407f7254',
      publish: true,
      order: 5,
      edit: '',
      isSelected: false
    },
    {
      name: 'USP',
      id: 'ad12aa94-3863-47f8-acab-2138ef02a3e9',
      publish: true,
      order: 17,
      edit: '',
      isSelected: false
    },
    {
      name: 'Premera',
      id: 'b899ec30-b85a-40ab-bb1f-22a596d5c6de',
      publish: true,
      order: 1,
      edit: '',
      isSelected: false
    },
    {
      name: 'Zeon',
      id: '07986d93-d4eb-4de1-9448-2338407f7254',
      publish: true,
      order: 6,
      edit: '',
      isSelected: false
    },
    {
      name: 'Zara',
      id: 'ad12aa94-3863-47f8-acab-2438ef02a3e9',
      publish: true,
      order: 5,
      edit: '',
      isSelected: false
    },
    {
      name: 'Pushpam',
      id: 'b899ec30-b85a-40ab-bb1f-25a596d5c6de',
      publish: true,
      order: 5,
      edit: '',
      isSelected: false
    },
    {
      name: 'Honda',
      id: '07986d93-d4eb-4de1-9448-2638407f7254',
      publish: true,
      order: 5,
      edit: '',
      isSelected: false
    },
    {
      name: 'Samsung',
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
  public filteredBrands = this.brands;
  public brandsDisplayedColumns: string[] = ['select', 'name', 'publish', 'order', 'edit'];
  public isAllSelected: boolean;
  public brandsDataSource = new MatTableDataSource<BrandOptions>(this.filteredBrands);


  constructor(private router: Router,
    private _route: ActivatedRoute,
    private _fuseConfirmationService: FuseConfirmationService) { }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    this.brandsDataSource.paginator = this.paginator.toArray()[0];
    this.brandsDataSource.sort = this.sort;
  }

  masterToggle(event): void {
    if (event.checked) {
      this.brands.forEach(x => x.isSelected = true);
    } else {
      this.brands.forEach(x => x.isSelected = false);
    }
  }

  toggleSelect(event, element): void {
    const foundBrand = this.brands.find(brand => brand.id === element.id);
    foundBrand.isSelected = event.checked;
    this.isAllSelected = this.brands.every(brand => brand.isSelected);
  }



  filterData(): void {
    this.filteredBrands = this.brands;
    this.brandsDataSource.filter = this.filterValue.name.trim().toLowerCase();
    switch (this.filterValue.publish) {
      case 'all':
        this.brandsDataSource.data = this.filteredBrands.filter(cat => cat);
        break;
      case 'published':
        this.brandsDataSource.data = this.filteredBrands.filter(cat => cat.publish);
        break;
      case 'unpublished':
        this.brandsDataSource.data = this.filteredBrands.filter(cat => !cat.publish);
        break;
      default:
        break;
    }
    this.brandsDataSource.paginator = this.paginator.toArray()[0];
  }

  clearSearchFilter(): void {
    this.filterValue = {
      name: '',
      publish: 'all'
    };
    this.filterData();
  }

  createBrand(): void {
    this.router.navigate(['create'], { relativeTo: this._route });
  }

  exportBrand(): void {

  }

  importBrand(): void {

  }

  deleteBrand(): void {
    const selectedBrands = this.brands.filter(b => b.isSelected);

    if (selectedBrands && selectedBrands.length) {
      const confirmation = this._fuseConfirmationService.open({
        title: 'Delete brand',
        message: 'Are you sure you want to remove this brand? This action cannot be undone!',
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
          this.brandsDataSource.data = this.brandsDataSource.data.filter(brand => !brand.isSelected);
        }
      });
    }

  }

  editBrand(brandId: string): void {
    this.router.navigate(['edit', brandId], { relativeTo: this._route });
  }


}
