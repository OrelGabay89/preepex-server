import { ChangeDetectionStrategy, Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-brand-items',
  templateUrl: './brand-items.component.html',
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BrandItemsComponent implements OnInit {

  public brandsPerSlide: number = 5;
  public brandForm: Array<any> = [];
  public brandItems = [
    {
      imageURL: 'http://demo.preepex.com/assets/images/logos/1.png',
      path: 'logos/premium'
    },
    {
      imageURL: 'http://demo.preepex.com/assets/images/logos/2.png',
      path: 'logos/elegant'
    }
  ];

  constructor() { }

  ngOnInit(): void {
    this.brandForm = [...this.brandItems];
  }

  addCarousel(): void {
    this.brandForm.push({
      imageURL: null,
      path: null
    });
  }

  removeCarousel(index: number): void {
    this.brandForm.splice(index, 1);
  }

  onFileDropped(data): void {
  }

  fileBrowseHandler(files): void {
  }

  trackByFn(index: number, item: any): any {
    return index;
  }
}
