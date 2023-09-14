import { ChangeDetectionStrategy, Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-category-items',
  templateUrl: './category-items.component.html',
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CategoryItemsComponent implements OnInit {

  public categoryForm: Array<any> = [];
  public categoryItems = [
    {
      imageURL: 'http://demo.preepex.com/assets/images/fashion-men.jpg',
      label: 'save 49%',
      path: 'shop/category?category=fashion',
      title: 'men'
    },
    {
      imageURL: 'http://demo.preepex.com/assets/images/fashion-women.jpg',
      label: 'save 51%',
      path: 'shop/category?category=fashion',
      title: 'women'
    }
  ];

  constructor() { }

  ngOnInit(): void {
    this.categoryForm = [...this.categoryItems];
  }

  addCarousel(): void {
    this.categoryForm.push({
      imageURL: null,
      label: null,
      path: null,
      title: null
    });
  }

  removeCarousel(index: number): void {
    this.categoryForm.splice(index, 1);
  }

  onFileDropped(data): void {
  }

  fileBrowseHandler(files): void {
  }

  trackByFn(index: number, item: any): any {
    return index;
  }

}
