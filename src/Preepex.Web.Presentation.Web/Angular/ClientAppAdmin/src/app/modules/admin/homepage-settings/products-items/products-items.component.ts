import { ChangeDetectionStrategy, Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-products-items',
  templateUrl: './products-items.component.html',
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProductsItemsComponent implements OnInit {

  public product = {
    itemsPerSlide: 3,
    title: 'products',
    label: 'special products',
    description: 'Product Description',
  };

  constructor() { }

  ngOnInit(): void {
  }

}
