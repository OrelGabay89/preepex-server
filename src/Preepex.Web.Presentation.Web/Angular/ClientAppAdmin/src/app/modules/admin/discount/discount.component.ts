import { AfterViewInit, Component, OnInit, QueryList, ViewChild, ViewChildren, ViewEncapsulation } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router, ActivatedRoute } from '@angular/router';
import { FuseConfirmationService } from '@fuse/services/confirmation';

@Component({
  selector: 'app-discount',
  templateUrl: './discount.component.html',
  encapsulation: ViewEncapsulation.None
})
export class DiscountComponent implements OnInit, AfterViewInit {
  @ViewChildren(MatPaginator) paginator = new QueryList<MatPaginator>();
  @ViewChild(MatSort) sort: MatSort;

  public discounts = [
    {
      name: '\'20% order total\' discount',
      id: 'b899ec30-b85a-40ab-bb1f-18a596d5c6de',
      type: 'Assigned to order total',
      discount: '20%',
      startDate: new Date(),
      endDate: new Date(),
      timeUsed: 0,
      edit: '',
    },
    {
      name: 'Sample discount with coupon code',
      id: '07986d93-d4eb-4de1-9448-2538407f7254',
      type: 'Assigned to products',
      discount: '10 USD',
      startDate: new Date(),
      endDate: new Date(),
      timeUsed: 0,
      edit: '',
    }
  ];

  public isLoading: boolean = false;
  public filteredDiscounts = this.discounts;
  public discountsDisplayedColumns: string[] = ['name', 'type', 'discount', 'startDate', 'endDate', 'timeUsed', 'edit'];
  public discountsDataSource = new MatTableDataSource<any>(this.filteredDiscounts);

  public filterValue = {
    startDate: null,
    endDate: null,
    coupenCode: '',
    discountName: '',
    discountType: 'all'
  };


  constructor(private router: Router,
    private _route: ActivatedRoute,
    private _fuseConfirmationService: FuseConfirmationService) { }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    this.discountsDataSource.paginator = this.paginator.toArray()[0];
    this.discountsDataSource.sort = this.sort;
  }

  public createDiscount(): void {
    this.router.navigate(['create'], { relativeTo: this._route });
  }

  filterData(): void {

  }

  clearSearchFilter(): void {

  }

  editDiscount(discountId: string): void {
    this.router.navigate(['edit', discountId], { relativeTo: this._route });
  }

}
