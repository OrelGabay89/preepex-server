import { ChangeDetectionStrategy, Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-special-products-items',
  templateUrl: './special-products-items.component.html',
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SpecialProductsItemsComponent implements OnInit {

  public specialProduct = {
    title: 'special products',
    label: 'exclusive products',
    newProducts: true,
    bestSeller: true,
    featuredProduct: true,
    onSale: true,
  };

  constructor() { }

  ngOnInit(): void {
  }

}
